using UnityEngine;
using UnityEngine.XR;

namespace Cereba Menu V1
{
    public static class PlatformsManager
    {
        private static GameObject leftPlatform;
        private static GameObject rightPlatform;

        public static void Update()
        {
            // Get left and right hands
            InputDevice leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

            bool leftGrip, rightGrip;
            leftHand.TryGetFeatureValue(CommonUsages.gripButton, out leftGrip);
            rightHand.TryGetFeatureValue(CommonUsages.gripButton, out rightGrip);

            Vector3 leftHandPos = GetHandWorldPosition(XRNode.LeftHand);
            Vector3 rightHandPos = GetHandWorldPosition(XRNode.RightHand);

            // Handle left platform
            if (leftGrip)
            {
                if (leftPlatform == null)
                {
                    leftPlatform = SpawnPlatform();
                }
                leftPlatform.transform.position = leftHandPos - new Vector3(0, 0.1f, 0);
            }
            else
            {
                if (leftPlatform != null) GameObject.Destroy(leftPlatform);
                leftPlatform = null;
            }

            // Handle right platform
            if (rightGrip)
            {
                if (rightPlatform == null)
                {
                    rightPlatform = SpawnPlatform();
                }
                rightPlatform.transform.position = rightHandPos - new Vector3(0, 0.1f, 0);
            }
            else
            {
                if (rightPlatform != null) GameObject.Destroy(rightPlatform);
                rightPlatform = null;
            }
        }

        private static GameObject SpawnPlatform()
        {
            GameObject platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
            platform.transform.localScale = new Vector3(0.35f, 0.05f, 0.35f); // Platform size
            platform.GetComponent<Renderer>().material.color = Color.blue;
            platform.layer = LayerMask.NameToLayer("Default");
            platform.name = "Platform";
            // Optionally set collider parameters here
            return platform;
        }

        // Get the world position of the hand
        private static Vector3 GetHandWorldPosition(XRNode handNode)
        {
            Vector3 localPos = InputTracking.GetLocalPosition(handNode);
            Quaternion localRot = InputTracking.GetLocalRotation(handNode);

            // If you have an XR Rig or player root, you may need to transform this
            // Assuming origin is at world 0,0,0 for simplicity
            return localPos;
        }
    }
}