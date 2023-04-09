using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection; 
using System.Collections;
using Il2Cpp;

namespace FullSwing
{
	public class FullSwingMain : MelonMod
	{
        public static Vector3 fullSwing = new Vector3(0.12f, 0, 0);
        public static float swingSpeed = 1;

        public override void OnInitializeMelon()
		{
            FullSwing.Settings.OnLoad();
            fullSwing = new Vector3(Settings.options.swingAngle, 0, 0);
            swingSpeed = Settings.options.swingSpeed;
        }

        public override void OnUpdate()
		{
            
        }
    }
}