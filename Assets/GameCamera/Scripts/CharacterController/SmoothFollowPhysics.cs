// Version 1.1.19
// ©2013 Reindeer Games
// All rights reserved
// Redistribution of source code without permission not allowed

using UnityEngine;

namespace RG_GameCamera.CharacterController
{
    public class SmoothFollowPhysics : MonoBehaviour
    {
        public bool Enabled = true;
        public float FollowSpeed = 10;

        private Vector3 lastPosition;
        private Vector3 localPosition;
        private Quaternion lastRotation;
        private Quaternion localRotation;

        void Start()
        {
            lastPosition = transform.position;
            localPosition = transform.parent.InverseTransformPoint(transform.position);
            lastRotation = transform.rotation;
            localRotation = Quaternion.Inverse(transform.parent.rotation) * transform.rotation;
        }

        void LateUpdate()
        {
            if (Enabled)
            {
                transform.position = Vector3.Lerp(lastPosition, transform.parent.TransformPoint(localPosition), Time.deltaTime * FollowSpeed);
                transform.rotation = Quaternion.Lerp(lastRotation, transform.parent.rotation * localRotation, Time.deltaTime * FollowSpeed);
            }

            lastPosition = transform.position;
            lastRotation = transform.rotation;
        }
    }
}
