using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleManger : MonoBehaviour
{
    public static RumbleManger rumbleManger;

    private void Start() {
        if(rumbleManger && rumbleManger != true) {
            Destroy(this);
        } else {
            rumbleManger = this;
        }
    }

    public void triggerRumble(int iteration, int frequency, int strength, OVRInput.Controller controller) {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++) {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

        if (controller == OVRInput.Controller.LTouch) {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if(controller == OVRInput.Controller.RTouch) {
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }

}
