using HarmonyLib;
using UnityEngine;
using Vent = OPPMFCFACJB;
using GameDataPlayerInfo = EGLJNOMOGNP.DCJMABDDJCF;
using PlayerControl = FFGALNAPKCD;

namespace CustomRolesMod
{
    [HarmonyPatch(typeof(Vent), "CanUse")]
    class VentPatch
    {
		public static bool Prefix(Vent __instance, ref float __result, [HarmonyArgument(0)] GameDataPlayerInfo pc, [HarmonyArgument(1)] out bool canUse, [HarmonyArgument(2)] out bool couldUse)
		{
			float num = float.MaxValue;
			PlayerControl @object = pc.LAOEJKHLKAI;
			couldUse = (pc.DAPKNDBLKIA || pc.JKOMCOJCAID == PlayerControlPatch.Sweeper.PlayerId) && !pc.DLPCKPBIJOE && (@object.GEBLLBHGHLD || @object.inVent);
			canUse = couldUse;
			if (canUse)
			{
				num = Vector2.Distance(@object.GetTruePosition(), __instance.transform.position);
				canUse &= num <= __instance.ILPBJHPGNBJ;
			}
			__result = num;
			return false;
		}
	}
}
