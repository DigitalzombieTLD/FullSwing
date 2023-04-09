using UnityEngine;
using ModSettings;
using MelonLoader;

namespace FullSwing
{
    internal class FullSwingSettings : JsonModSettings
    {     

		[Section("Fridge Doors")]

        [Name("Swing Radius")]
        [Description("Left: Original radius; Right: Bigger radius")]
        [Slider(0.03f, 0.60f)]
        public float swingAngle = 0.03f;

        [Name("Swing Speed")]
		[Description("Left: Original speed; Right: Faster speed")]
		[Slider(1f, 0f)]
		public float swingSpeed = 1f;

		protected override void OnConfirm()
        {
            base.OnConfirm();
            FullSwingMain.fullSwing = new Vector3 (swingAngle, 0, 0);
            FullSwingMain.swingSpeed = swingSpeed;
        }
    }

    internal static class Settings
    {
        public static FullSwingSettings options;

        public static void OnLoad()
        {
            options = new FullSwingSettings();
            options.AddToModSettings("FullSwing");           
        }
    }
}
