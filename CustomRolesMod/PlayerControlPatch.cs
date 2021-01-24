using System.Collections.Generic;
using HarmonyLib;
using Hazel;
using UnhollowerBaseLib;
using PlayerControl = FFGALNAPKCD;
using GameDataPlayerInfo = EGLJNOMOGNP.DCJMABDDJCF;
using AmongUsClient = FMLLKEACGIO;

namespace CustomRolesMod
{
	[HarmonyPatch]
	public static class PlayerControlPatch
	{
		public static PlayerControl Torch;

		public static PlayerControl Mayor;

		public static PlayerControl Sweeper;
		
		[HarmonyPatch(typeof(PlayerControl), "HandleRpc")]
		public static void Postfix([HarmonyArgument(0)] byte callId, [HarmonyArgument(1)] MessageReader reader)
		{
			if (callId == 41)
			{
				byte readByte = reader.ReadByte();
				foreach (PlayerControl player in PlayerControl.AllPlayerControls)
				{
					if (player.PlayerId == readByte)
					{
						PlayerControlPatch.Torch = player;
					}
				}
			}
			if (callId == 42)
			{
				byte readByte = reader.ReadByte();
				foreach (PlayerControl player in PlayerControl.AllPlayerControls)
				{
					if (player.PlayerId == readByte)
					{
						Mayor = player;
					}
				}
			}
			if (callId == 43)
			{
				byte readByte = reader.ReadByte();
				foreach (PlayerControl player in PlayerControl.AllPlayerControls)
				{
					if (player.PlayerId == readByte)
					{
						PlayerControlPatch.Sweeper = player;
					}
				}
			}
		}

		public static bool isTorch(PlayerControl player)
		{
			return player.PlayerId == PlayerControlPatch.Torch.PlayerId;
		}
		
		public static bool IsMayor(PlayerControl player)
		{
			return player.PlayerId == PlayerControlPatch.Mayor.PlayerId;
		}

		public static bool IsSweeper(PlayerControl player)
		{
			return player.PlayerId == PlayerControlPatch.Sweeper.PlayerId;
		}

		public static List<PlayerControl> getCrewMates(Il2CppReferenceArray<GameDataPlayerInfo> infection)
		{
			List<PlayerControl> list = new List<PlayerControl>();
			foreach (PlayerControl player in PlayerControl.AllPlayerControls)
			{
				bool isImpostor = false;
				foreach (GameDataPlayerInfo player1 in infection)
				{
					if (player.PlayerId == player1.LAOEJKHLKAI.PlayerId)
					{
						isImpostor = true;
						break;
					}
				}
				if (!isImpostor)
				{
					list.Add(player);
				}
			}
			return list;
		}


		[HarmonyPatch(typeof(PlayerControl), "RpcSetInfected")]
		public static void Postfix([HarmonyArgument(0)] Il2CppReferenceArray<GameDataPlayerInfo> infected)
		{
			MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, 41, SendOption.None, -1);
			List<PlayerControl> crewMates = getCrewMates(infected);
			System.Random random = new System.Random();
			Torch = crewMates[random.Next(0, crewMates.Count)];
			byte playerId = Torch.PlayerId;
			messageWriter.Write(playerId);
			AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
			crewMates.Remove(Torch);
			messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, 42, SendOption.None, -1);
			System.Random random1 = new System.Random();
			Mayor = crewMates[random1.Next(0, crewMates.Count)];
			byte playerId1 = Mayor.PlayerId;
			messageWriter.Write(playerId1);
			AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
			crewMates.Remove(Mayor);
			messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, 43, SendOption.None, -1);
			System.Random random2 = new System.Random();
			Sweeper = crewMates[random2.Next(0, crewMates.Count)];
			byte playerId2 = Sweeper.PlayerId;
			messageWriter.Write(playerId2);
			AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
		}
	}
}
