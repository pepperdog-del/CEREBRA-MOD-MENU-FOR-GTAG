using BepInEx;
using UnityEngine;

namespace Cerebra Menu V1
{
    [BepInPlugin("gtag.Cerebra.pepperdog", "Cerebra Menu V1", "1.0.0")]
    public class CerebraMenuV1Plugin : BaseUnityPlugin
    {
        public static CerebraMenuV1Plugin Instance;
        private ModMenu _modMenu;

        private void Awake()
        {
            Instance = this;
            _modMenu = new ModMenu();
            Logger.LogInfo("Cerebra Menu V1 loaded!");
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