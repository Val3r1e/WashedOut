using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using FMODUnity;

public class PixelInteractionRight : MonoBehaviour
{
    //Door
    public GameObject door;
    //Instructions
    public SpriteRenderer instruction;
    //Particles
    public ParticleSystem cone;
    public ParticleSystem pixel;
    //PointLight
    public Light2D pointLight;
    //Wether door was triggered 
    public bool wasTriggered = false;

    Animator doorAnimator;

    public StudioEventEmitter pickingUp;

    bool triggerEnter = false;

    void Start()
    {
        
        //Door animator
        doorAnimator = door.GetComponent<Animator>();
        
        //Disable door
        door.SetActive(false);

        //Don't show instructions
        instruction.enabled = false;

        //Turn off pixel
        pointLight.enabled = false;
        cone.Pause();
        pixel.Pause();

        
    }

    void Update()
    {
        //If the pixel is active & wasn't triggered yet
        if (gameObject.activeSelf && !wasTriggered)
        {
            //Turn on point light
            pointLight.enabled = true;

            //Turn on particles
            cone.Play();
            pixel.Play();
        }
        //If "E" was pressed 
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            //Make pixel disappear & stop playing the sound 
            gameObject.SetActive(false);
            pointLight.enabled = false;
            cone.Stop();
            pixel.Stop();

            //Play picking up sound
            pickingUp.Play();

            //Pixel was triggered
            wasTriggered = true;

            triggerEnter = false;

            //Stop showing instructions 
            instruction.enabled = false;

            //Make door appear
            door.SetActive(true);
            doorAnimator.SetBool("HasInteracted", true);            
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //If the pixel is active & wasn't triggered yet
        if(gameObject.activeSelf && !wasTriggered)
        {
            //Show instructions
            instruction.enabled = true;
            triggerEnter = true;
        }
    }

    /*void OnTriggerStay2D(Collider2D c)
    {
        //If "E" was pressed 
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Make pixel disappear & stop playing the sound 
            gameObject.SetActive(false);
            pointLight.enabled = false;
            cone.Stop();
            pixel.Stop();

            //Play picking up sound
            pickingUp.Play();

            //Pixel was triggered
            wasTriggered = true;

            //Stop showing instructions 
            instruction.enabled = false;

            //Make door appear
            door.SetActive(true);
            doorAnimator.SetBool("HasInteracted", true);            
        }
    }*/

    void OnTriggerExit2D(Collider2D c)
    {
        instruction.enabled = false;
    }
}
