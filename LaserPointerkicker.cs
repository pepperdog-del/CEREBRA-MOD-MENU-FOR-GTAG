using UnityEngine;

namespace Cerebra Menu V1
{
    public static class LaserPointerKicker
    {
        private static bool isActive = false;

        public static void ToggleLaser()
        {
            isActive = !isActive;
            Debug.Log("Laser pointer " + (isActive ? "enabled" : "disabled"));
        }

        // Call this from Update loop if laser is active
        public static void Update()
        {
            if (!isActive) return;

            // Raycast from hand/controller, draw laser, check what player is aimed at
            // On trigger/fire, call KickManager.KickPlayer(target)
            // Implement VR controller input and player selection here
        }
    }
}