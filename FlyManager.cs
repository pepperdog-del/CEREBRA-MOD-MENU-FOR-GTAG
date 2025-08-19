using UnityEngine;
using UnityEngine.XR;

namespace Cerebra Menu V1
{
    public static class FlyManager
    {
        private static bool isFlying = false;

        // Called each frame from plugin update
        public static void Update()
        {
            // Check top button on left controller to toggle fly
            InputDevice leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            bool buttonState = false;
            if (leftHand.TryGetFeatureValue(CommonUsages.primaryButton, out buttonState) && buttonState)
            {
                // Toggle fly ON
                isFlying = true;
            }
            else
            {
                // Toggle fly OFF
                isFlying = false;
            }

            if (isFlying)
            {
                FlyLogic();
            }
        }

        // Fly logic (move player up while flying)
        private static void FlyLogic()
        {
            // Replace this with Gorilla Tag's local player reference
            GameObject player = /* get local player object */;
            if (player != null)
            {
                // Example: Move up while flying
                player.transform.position += Vector3.up * Time.deltaTime * 5f;
            }
        }
    }
}