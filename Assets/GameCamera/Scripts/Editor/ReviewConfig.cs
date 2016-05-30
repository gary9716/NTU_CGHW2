using UnityEngine;
using System.Collections;

namespace RG_GameCamera
{
    [System.Serializable]
    public class ReviewConfig : ScriptableObject
    {
        //[HideInInspector]
        public bool active = true;

        //[HideInInspector]
        public int counter = 0;

        //[HideInInspector]
        public double lastCheck = 0;
    }
}
