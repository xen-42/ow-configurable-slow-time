using HarmonyLib;
using HarmonyLib.Tools;
using OWML.Common;
using OWML.ModHelper;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ConfigurableSlowTime
{
    public class ConfigurableSlowTime : ModBehaviour
    {
        public static ConfigurableSlowTime Instance;
        public float loopLengthMinutes = 42f;

        public void Awake()
        {
            Instance = this;
        }

        public void Start()
        {

        }

        public override void Configure(IModConfig config)
        {
            loopLengthMinutes = config.GetSettingsValue<float>(nameof(loopLengthMinutes));
        }

        public void Update()
        {
            // Doesn't take into account stuff like getting to the QM that extends the loop but oh well
            float multiplier = TimeLoop.GetLoopDuration() / (loopLengthMinutes * 60);
            float timeRemaining = TimeLoop.GetLoopDuration() - (Time.timeSinceLevelLoad * multiplier);
            TimeLoop.SetSecondsRemaining(timeRemaining);
        }
    }
}
