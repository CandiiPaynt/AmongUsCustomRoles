using HarmonyLib;
using ShipStatus = HLBNNHFCNAJ;
using GameData = EGLJNOMOGNP;

namespace CustomRolesMod
{
	[HarmonyPatch(typeof(ShipStatus), "CalculateLightRadius")]
	public static class ShipStatusPatch
	{
		public static bool Prefix([HarmonyArgument(0)] GameData.DCJMABDDJCF player, ShipStatus __instance, ref float __result)
		{
			if (player.JKOMCOJCAID == PlayerControlPatch.Torch.PlayerId)
			{
				__result = 10f;
				return false;
			}
			return true;
		}
	}
}
