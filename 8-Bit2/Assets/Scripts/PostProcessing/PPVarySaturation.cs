using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPVarySaturation : MonoBehaviour
{
    float min = 0;
    float max = -40;
    float speed = 0.03f;
    float amount = 0;

    UnityEngine.Rendering.Universal.ColorAdjustments colorAdjust = null;
    //UnityEngine.Rendering.Universal.ChromaticAberration aberration = null;

    private void Start()
    {
        UnityEngine.Rendering.VolumeProfile volumeProfile = GetComponent<UnityEngine.Rendering.Volume>()?.profile;

        volumeProfile.TryGet(out colorAdjust);
        //volumeProfile.TryGet(out aberration);

        min = (float)colorAdjust.saturation;
    }

    private void Update()
    {
        if(GameObject.Find("Bench").GetComponent<AtBench>().sunsetStart)
        {
            if (amount < 1)
            {
                amount += Time.deltaTime * speed; 
                colorAdjust.saturation.Override((float)Mathf.SmoothStep(min, max, amount));

            }
        }
        
    }
}
