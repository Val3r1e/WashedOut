using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PPVaryAberration : MonoBehaviour
{
    //Chromatic Aberration values
    float min = 0.1f;
    public float max = 0.5f;
    float speed = 1.2f;

    //UnityEngine.Rendering.Universal.ColorAdjustments colorAdjust = null;
    UnityEngine.Rendering.Universal.ChromaticAberration aberration = null;

    private void Start()
    {
        UnityEngine.Rendering.VolumeProfile volumeProfile = GetComponent<UnityEngine.Rendering.Volume>()?.profile;

        //volumeProfile.TryGet(out colorAdjust);
        volumeProfile.TryGet(out aberration);
    }

    private void Update()
    {
        //Vary intensity 
        aberration.intensity.Override((float)Mathf.SmoothStep(min, max, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f));
    }
}
