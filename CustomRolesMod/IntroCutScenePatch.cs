using HarmonyLib;
using UnityEngine;
using IntroCutscene_CoBegin_d__10 = PENEIDJGGAF.CKACLKCOJFO;
using PlayerControl = FFGALNAPKCD;

namespace CustomRolesMod
{
	[HarmonyPatch]
	public static class IntroCutScenePatch
	{
		[HarmonyPatch(typeof(IntroCutscene_CoBegin_d__10), "MoveNext")]
		public static void Postfix(IntroCutscene_CoBegin_d__10 __instance)
		{
			if (PlayerControlPatch.isTorch(PlayerControl.LocalPlayer))
			{
				__instance.field_Public_PENEIDJGGAF_0.Title.Text = "Torch";
				__instance.field_Public_PENEIDJGGAF_0.Title.Color = new Color(1f, 0.37f, 0.125f, 1f);
				__instance.field_Public_PENEIDJGGAF_0.ImpostorText.Text = "You have full vision even when the lights are out";
				__instance.field_Public_PENEIDJGGAF_0.BackgroundBar.material.color = new Color(1f, 0.37f, 0.125f, 1f);
			}
			if (PlayerControlPatch.IsSweeper(PlayerControl.LocalPlayer))
			{
				__instance.field_Public_PENEIDJGGAF_0.Title.Text = "Sweeper";
				__instance.field_Public_PENEIDJGGAF_0.Title.Color = new Color(0f, 0.33f, 0.79f, 1f);
				__instance.field_Public_PENEIDJGGAF_0.ImpostorText.Text = "Use vents to move around";
				__instance.field_Public_PENEIDJGGAF_0.BackgroundBar.material.color = new Color(0f, 0.33f, 0.79f, 1f);
			}
			if (PlayerControlPatch.IsMayor(PlayerControl.LocalPlayer))
			{
				__instance.field_Public_PENEIDJGGAF_0.Title.Text = "Mayor";
				__instance.field_Public_PENEIDJGGAF_0.Title.Color = new Color(0.44f, 0.31f, 0.66f, 1f);
				__instance.field_Public_PENEIDJGGAF_0.ImpostorText.Text = "Your vote counts twice";
				__instance.field_Public_PENEIDJGGAF_0.BackgroundBar.material.color = new Color(0.44f, 0.31f, 0.66f, 1f);
			}
		}
	}
}
