using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

	public GameObject cameraPlayer;
	private float startPos;
	public float speedParallax;

    void Start()
    {
       startPos = transform.position.x;
    }

    void FixedUpdate()
    {
    	float dist = (cameraPlayer.transform.position.x * speedParallax);

    	transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}
