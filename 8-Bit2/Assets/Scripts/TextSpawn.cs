using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSpawn : MonoBehaviour
{

	public GameObject centerPoint; //the centerpoint
	public float speedOrbit; //orbit speed
	public float speedAlpha = 5; //alpha speed
	[SerializeField] [Range(0, 1)] float maxAlpha;
    float minAlpha = 0;
    TextMeshPro textmeshPro;

	void Start(){
		textmeshPro = GetComponent<TextMeshPro>();
        textmeshPro.color = new Color(1, 1, 1, 0);
	}

    // Update is called once per frame
    void Update(){

    	OrbitAround(); //make the words rotate
    	ChangeAlpha(); //change color
    }

    void OrbitAround(){
    	transform.RotateAround(centerPoint.transform.position, Vector3.back, speedOrbit * Time.deltaTime);
    	//orbit around centerpoint
    }

    void ChangeAlpha(){
    	textmeshPro = GetComponent<TextMeshPro>();
    	float time = Mathf.PingPong(Time.time * speedAlpha, 1);

    	float alpha = Mathf.SmoothStep(minAlpha, maxAlpha ,time);

        textmeshPro.color = new Color(1, 1, 1, alpha);
    }
}