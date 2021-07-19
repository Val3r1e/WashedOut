using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PixelInteraction : MonoBehaviour
{
    //Right pixel
    public GameObject pixelRight;
    //Instructions
    public SpriteRenderer instruction;
    //Light of this pixel 
    public Light2D pointLight;
    public ParticleSystem cone;
    public ParticleSystem pixel;
    public bool wasTriggered = false;
    bool triggerEnter = false;

    void Start()
    {
        //Turn of right pixel
        pixelRight.SetActive(false);

        //Don't show instructions 
        instruction.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            instruction.enabled = true;
            triggerEnter = true;
        }
    }

    void Update()
    {
        //If "E" was pressed 
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            //Make right pixel appear & start playing the sound 
            pixelRight.SetActive(true);
            wasTriggered = true;

            //Make pixel disappear & stop playing the sound
            gameObject.SetActive(false);
            pointLight.enabled = false; 
            cone.Stop();
            pixel.Stop();

            //Make instruction disappear
            instruction.enabled = false;
            triggerEnter = false;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        instruction.enabled = false;
        triggerEnter = false;
    }
}