// uncomment next line to work with Playmaker
//#define PLAYMAKER
#if PLAYMAKER

// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Camera)]
    [Tooltip("Set camera target")]
    public class GameCameraConfigurationAction : FsmStateAction
    {
        [Tooltip("Type of game camera")]
        public FsmGameObject CameraTarget;

        [Tooltip("Configuration of camera mode")]
        public FsmString Configuration;

        public override void OnEnter()
        {
            var cm = RG_GameCamera.CameraManager.Instance;

            if (!string.IsNullOrEmpty(Configuration.Value) && cm != null && cm.GetCameraMode() != null)
            {
                cm.GetCameraMode().SetCameraConfigMode(Configuration.Value);
            }
        }
    }
}

#endif
