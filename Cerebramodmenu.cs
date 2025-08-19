using UnityEngine;

namespace Cerebra Menu v1
{
    public class Cerebra Menu V1    {
        private bool showMenu = false;
        private int currentPage = 0; // 0 = Main, 1 = Helpful Mods, 2 = Settings

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F1))
                showMenu = !showMenu;
        }

        public void OnGUI()
        {
            if (!showMenu) return;

            // Settings button at top, all pages
            if (GUI.Button(new Rect(20, 20, 100, 25), "Settings"))
                currentPage = 2;

            if (currentPage == 0)
            {
                GUI.Box(new Rect(20, 50, 260, 260), "Cerebra Menu v1.1");

                if (GUI.Button(new Rect(40, 90, 200, 30), "Kick All")) KickManager.KickAllPlayers();
                if (GUI.Button(new Rect(40, 130, 200, 30), "Kick Gun (Laser)")) LaserPointer.ToggleLaser();
                GUI.Label(new Rect(40, 170, 200, 30), "Fly Mod: Top button on left controller");
                GUI.Label(new Rect(40, 200, 200, 30), "Platforms: Grip button on either hand");
                if (GUI.Button(new Rect(40, 240, 200, 30), "Helpful Mods")) currentPage = 1;
            }
            else if (currentPage == 1)
            {
                GUI.Box(new Rect(20, 50, 260, 300), "Cerebra Menu v1.1");

                if (GUI.Button(new Rect(40, 90, 200, 30), "Long Arms")) HelpfulModsManager.ToggleLongArms();
                if (GUI.Button(new Rect(40, 130, 200, 30), "Wall Walk")) HelpfulModsManager.ToggleWallWalk();
                if (GUI.Button(new Rect(40, 170, 200, 30), "Auto Wall Walk")) HelpfulModsManager.ToggleAutoWallWalk();
                if (GUI.Button(new Rect(40, 210, 200, 30), $"Speed Boost: {(HelpfulModsManager.SpeedBoostActive ? "ON" : "OFF")}")) HelpfulModsManager.ToggleSpeedBoost();
                if (GUI.Button(new Rect(40, 270, 200, 30), "Back")) currentPage = 0;
                GUI.Label(new Rect(40, 230, 200, 30), "Speedboost: Uses setting from Settings page");
            }
            else if (currentPage == 2)
            {
                GUI.Box(new Rect(20, 50, 260, 220), "Cerebra Menu v1.1");

                if (GUI.Button(new Rect(40, 90, 200, 30), $"6 ft Long Arms: {HelpfulModsManager.GetLongArmsHeight(1)}")) HelpfulModsManager.CycleLongArmsHeight(1);
                if (GUI.Button(new Rect(40, 130, 200, 30), $"5'5-6'0 Arms: {HelpfulModsManager.GetLongArmsHeight(2)}")) HelpfulModsManager.CycleLongArmsHeight(2);
                if (GUI.Button(new Rect(40, 170, 200, 30), $"Speed Boost Level: {HelpfulModsManager.GetSpeedBoostLevel()}")) HelpfulModsManager.CycleSpeedBoostLevel();
                if (GUI.Button(new Rect(40, 200, 200, 30), "Back")) currentPage = 0;
            }
        }
    }
}