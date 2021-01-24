using HarmonyLib;
using VersionShower = BOCOFLHKCOJ;

namespace CustomRolesMod
{
	[HarmonyPatch(typeof(VersionShower), "Start")]
	public static class VersionShowerPatch
	{
		public static void Postfix(VersionShower __instance)
		{
			AELDHKGBIFD text = __instance.text;
			text.Text += " + [FF5F20FF]Cust[][704FA8FF]om R[][0054C9FF]oles[] Mod by Tomozbot";
		}
	}
}
