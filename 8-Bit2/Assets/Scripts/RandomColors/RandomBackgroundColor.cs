using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create a sprite renderer if there is none
[RequireComponent(typeof(SpriteRenderer))]

public class RandomBackgroundColor : MonoBehaviour
{
	private SpriteRenderer backgroundRenderer;
	public float timeToChange = 0.1f;
	private float timeSinceChange = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        backgroundRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	timeSinceChange += Time.deltaTime;
    	//Make sure renderer is set
    	if(backgroundRenderer != null && timeSinceChange >= timeToChange){
    		
/*
    		Color newColor = new Color(

    			Random.value,
    			Random.value,
    			Random.value
    			);
    			*/

    		backgroundRenderer.color = Random.ColorHSV(0f, 0.5f, 1f, 1f, 0.5f, 1f);
    		timeSinceChange = 0f;
    	}

 
    }

}
