using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelateEffect : MonoBehaviour
{

	[SerializeField] public Material material;

    public float minimum = 0f;
    public float max = 0.2f;
    public float speed = 2f;

    float pixelAmount;

    // Start is called before the first frame update
    void Start()
    {
        pixelAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        float time = Mathf.PingPong(Time.time * speed, 1);

        //float rY = Mathf.SmoothStep(currentY, minY ,time);

        //pixelAmount = (float)Mathf.SmoothStep(minimum, max, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        pixelAmount = Mathf.SmoothStep(minimum, max, time);
        
        material.SetFloat("_PixelAmount", pixelAmount);
    }
}
