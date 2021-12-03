using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class Gun : MonoBehaviour
{
    public float test;


    [Header("Rumble settings")]
    [SerializeField] int iteration = 40;
    [SerializeField] int frequency = 40;
    [SerializeField] int strength = 40;

    private void Update() {
        

        test = Mathf.Max(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger));
        if (test > 0.5f) {
            RumbleManger.rumbleManger.triggerRumble(iteration, frequency, strength, OVRInput.Controller.LTouch);
        }
    }
}
