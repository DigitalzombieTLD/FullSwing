using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace FullSwing
{    
    
    [HarmonyLib.HarmonyPatch(typeof(ObjectAnim), "Play")]
    public class SwingPatches
    {
        public static void Prefix(ref ObjectAnim __instance, ref string name)
        {
            if (__instance.m_Target != null && __instance.m_Events != null)
            {
                iTweenEvent openEvent = new iTweenEvent();
                iTweenEvent closeEvent = new iTweenEvent();

                if (name == "close" || name == "open" && __instance.gameObject.name == "Door")
                {
                    foreach (iTweenEvent singleEvent in __instance.m_Events) 
                    {
                        if (singleEvent.tweenName == "open")
                        {
                            openEvent = singleEvent;
                        }

                        if (singleEvent.tweenName == "close")
                        {
                            closeEvent = singleEvent;                            
                        }
                    }

                    if (name == "open")
                    {
                        openEvent.vector3s[0] = FullSwingMain.fullSwing;
                        closeEvent.vector3s[0] = new Vector3(-FullSwingMain.fullSwing.x, 0, 0);

                        openEvent.floats[0] = FullSwingMain.swingSpeed;
                        closeEvent.floats[0] = FullSwingMain.swingSpeed;

                        openEvent.DeserializeValues();
                        closeEvent.DeserializeValues();
                    }                   
                }     
            }           
        }
    }    
}
