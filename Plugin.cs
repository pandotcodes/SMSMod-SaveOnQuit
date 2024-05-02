using BepInEx;
using HarmonyLib;
using MyBox;
using System.Collections;
using UnityEngine;

namespace SaveOnQuit
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded! Applying patch...");
            Harmony harmony = new Harmony("com.orpticon.SaveOnQuit");
            harmony.PatchAll();
        }
    }
    public static class SaveOnQuitPatch
    {

        [HarmonyPatch(typeof(EscapeMenuManager), "Quit")]
        public static class EscapeMenuManager_Quit_Patch
        {
            public static void Prefix()
            {
                Singleton<SaveManager>.Instance.Save();
            }
        }
    }
}
