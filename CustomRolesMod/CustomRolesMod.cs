using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;

namespace CustomRolesMod
{
	[BepInPlugin("gg.tomozbot.customrolesmod", "Custom Roles Mod Mod", "1.0.0")]
	public class CustomRolesMod : BasePlugin
	{
		public override void Load()
		{
			this._harmony = new Harmony("gg.tomozbot.customrolesmod");
			this._harmony.PatchAll();
		}

		private Harmony _harmony;
	}
}
