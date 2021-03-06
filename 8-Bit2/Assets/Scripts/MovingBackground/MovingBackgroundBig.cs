using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgroundBig : MonoBehaviour
{

    public float maxY;
    float minY;

    [SerializeField] [Range(0f, 2f)] float speed = 0.25f;

    // Start is called before the first frame update
    void Start()
    {

    minY = -maxY;

    }

    // Update is called once per frame
    void Update()
    {

        float time = Mathf.PingPong(Time.time * speed, 1);

        float rY = Mathf.SmoothStep(minY, maxY ,time);

        transform.localPosition = new Vector3(0, rY, 0);

    }
}
