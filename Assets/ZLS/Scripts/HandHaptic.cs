using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HandHaptic : MonoBehaviour
{
    public SteamVR_Action_Vibration vibration;
 
    public void vibrating(float duration,float frequency,float amplitude,SteamVR_Input_Sources source)
    {
        vibration.Execute(0, duration, frequency, amplitude,source);
    }

}
