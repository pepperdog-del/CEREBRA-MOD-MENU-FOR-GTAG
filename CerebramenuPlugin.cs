using BepInEx;
using UnityEngine;

namespace Cerebra Menu V1
{
    [BepInPlugin("gtag.modmenu.pepperdog", "Gtag Mod Menu", "1.0.0")]
    public class GtagModMenuPlugin : BaseUnityPlugin
    {
        public static GtagModMenuPlugin Instance;
        private ModMenu _modMenu;

        private void Awake()
        {
            Instance = this;
            _modMenu = new ModMenu();
            Logger.LogInfo("Gtag Mod Menu loaded!");
        }

        private void Update()
        {
            _modMenu.OnUpdate();
            FlyManager.Update();
            PlatformsManager.Update();
            HelpfulModsManager.Update(); // Add this for Helpful Mods
        }

        private void OnGUI()
        {
            _modMenu.OnGUI();
        }
    }
}