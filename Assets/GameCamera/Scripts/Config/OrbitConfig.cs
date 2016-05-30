﻿// Version 1.1.19
// ©2013 Reindeer Games
// All rights reserved
// Redistribution of source code without permission not allowed

using System.Collections.Generic;
using UnityEngine;

namespace RG_GameCamera.Config
{
    public class OrbitConfig : Config
    {
        /// <summary>
        /// initialize default config values
        /// </summary>
        public override void LoadDefault()
        {
            var defaultParams = new Dictionary<string, Param>
            {
                {"FOV",             new RangeParam {value = 60.0f, min = 20.0f, max = 100.0f }}, // field of view
                {"ZoomSpeed", new RangeParam {value = 2.0f, min = 0.0f, max = 10.0f}},      // speed of zooming, higher is faster
                {"RotationSpeedX", new RangeParam {value = 8.0f, min = 0.0f, max = 10.0f}}, // speed of rotating in X, higher is faster
                {"RotationSpeedY", new RangeParam {value = 5.0f, min = 0.0f, max = 10.0f}}, // speed of rotating in Y, higher is faster
                {"PanSpeed", new RangeParam {value = 1.0f, min = 0.0f, max = 10.0f}},       // speed of panning

                {"RotationYMax", new RangeParam {value = 90, min = 0, max = 90}},           // rotation limit in z-up axix
                {"RotationYMin", new RangeParam {value = -90, min = -90, max = 0}},         // rotation limit in z-down axis

                {"DragLimits", new BoolParam  {value = false}},                             // enable drag limits
                {"DragLimitX", new Vector2Param {value = new Vector2(-10, 10) }},           // drag limit in x-axis
                {"DragLimitY", new Vector2Param {value = new Vector2(-10, 10) }},           // drag limit in y-axis
                {"DragLimitZ", new Vector2Param {value = new Vector2(-10, 10) }},           // drag limit in y-axis

                {"DisablePan", new BoolParam {value = false}},
                {"DisableZoom", new BoolParam {value = false}},
                {"DisableRotation", new BoolParam {value = false}},
                {"TargetInterpolation", new RangeParam { value = 0.5f, min = 0.0f, max = 1.0f }},
                {"Orthographic",    new BoolParam { value = false }},                            // enable orthographic projection
                {"UseInitialSettings", new BoolParam {value = false}},
                {"InitialPosition", new Vector3Param {value = new Vector3(0, 0, 0) }},           // initial position
                {"InitialZoom", new RangeParam {value = 0, min = -10, max = 10}},                   // initial zoom
            };

            Params = new Dictionary<string, Dictionary<string, Param>> { { "Default", defaultParams } };
            Transitions = new Dictionary<string, float>();
            foreach (var param in Params)
            {
                Transitions.Add(param.Key, 0.25f);
            }
            Deserialize(DefaultConfigPath);

            base.LoadDefault();
        }

        protected override void Awake()
        {
            base.Awake();
            LoadDefault();
        }
    }
}