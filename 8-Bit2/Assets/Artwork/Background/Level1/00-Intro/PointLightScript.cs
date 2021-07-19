using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PointLightScript : MonoBehaviour {

	Light2D fireLight;
	float lightInt;
	public float minInt = 3f, maxInt = 5f;

	// Use this for initialization
	void Start () {
		fireLight = GetComponent<Light2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		lightInt = Random.Range (minInt, maxInt);
		fireLight.intensity = lightInt;
	}
}
