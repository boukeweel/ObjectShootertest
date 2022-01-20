using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class RumbleGun : MonoBehaviour
{
    
    [Header("Rumble settings")]
    [SerializeField] int iteration = 40;
    [SerializeField] int frequency = 40;
    [SerializeField] int strength = 40;

    
        
     public void RumbleController()
     {
        RumbleManger.rumbleManger.triggerRumble(iteration, frequency, strength, OVRInput.Controller.LTouch);
     }
}
