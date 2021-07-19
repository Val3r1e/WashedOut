using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Cinemachine;

public class MoveInAndOut : MonoBehaviour
{
    public SpriteRenderer instruction;
    public GameObject tuningObject;

    //Cameras
    public GameObject virtualCamera;
    public GameObject virtualCameraZoomedIn;
    CinemachineVirtualCamera currentCamera;
    CinemachineVirtualCamera oldCamera;

    //Growing and shrinking
    public SpriteRenderer srenderer;
    public float minWidth = 0.2f;
    public float maxWidth = 0.5f;
    public float speed = 0f;
    float amount = 0;
    Vector2 currentSize;
    Vector2 currentSize2;

    //Shaking
    public float shakeSpeed = 50f;
    public float shakeAmount = 0.0019f;
    float startX = 0;
    float startY = 0;

    //Animator of fuzzy object
    Animator animator;
    //Fuzzy sound
    StudioEventEmitter emitter;

    bool isInside = false;

    // Start is called before the first frame update
    void Start()
    {
        //Don't show instructions
        instruction.enabled = false;

        //Get animator of fuzzy object
        animator = tuningObject.GetComponent<Animator>();

        //Get sound emitter of fuzzy sound
        emitter = tuningObject.GetComponent<StudioEventEmitter>();

        //Get Cameras
        currentCamera = virtualCameraZoomedIn.GetComponent<CinemachineVirtualCamera>();
        oldCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();

        //Current size of bar
        currentSize = srenderer.size;
        currentSize2 = srenderer.size;

        //Current position of bar
        startX = gameObject.transform.position.x;
        startY = gameObject.transform.position.y;
    }

    void Update()
    {
        instruction.enabled = true;

        //Freeze Player
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = true;

        //IF MaxWidth is reached and it's still growing 
        if (Input.GetKey(KeyCode.E) && currentSize.x >= maxWidth)
        {
            Debug.Log("Let go! (Breathe out!)");

            //Shake bar
            gameObject.transform.position = new Vector2(startX + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, startY + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount);

            //Move bar from inside(min) to outside(max)
            if (amount < 1)
            {
                //Increments amount based on Time.deltaTime multiplied by speed
                amount += Time.deltaTime * (speed-0.1f);
                srenderer.size = new Vector2(Mathf.Lerp(minWidth - 0.2f, maxWidth + 0.5f, amount), 0.2f);
                currentSize = srenderer.size;

            }
            shakeSpeed += 50;
            shakeAmount += 0.0001f;
        }

        //If I is pressed
        else if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("Press E! (Breathe in!)");
            //Don't show instructions
            instruction.enabled = false;

            isInside = true;

            //Move bar from inside(min) to outside(max)
            if (amount < 1)
            {
                //Increments amount based on Time.deltaTime multiplied by speed
                amount += Time.deltaTime * speed;
                srenderer.size = new Vector2(Mathf.Lerp(minWidth - 0.2f, maxWidth+0.5f, amount), 0.2f);
                currentSize = srenderer.size;
            }
        }

        //ELSE IF I is was pressed to long and MaxWidth has been exceeded  
        else if (Input.GetKeyUp(KeyCode.E) && currentSize.x.Equals(maxWidth+0.5f))
        {
            Debug.Log("Pressed too long! (I can't breathe like this)");

            //Turn renderer of tuning system off
            GameObject.Find("Sign").GetComponent<SignInteraction>().tuning.SetActive(false);
            //Start animation of fuzzy object
            animator.SetBool("clear", true);
            //Turn of fuzzy sound
            emitter.enabled = false;
            //Trigger dialogue
            GetComponent<ConversationTrigger>().TriggerDialogue();
            oldCamera.enabled = true;
            currentCamera.enabled = false;

        }

        //ELSE IF the dialogue has finished
        else if (isInside && GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done)
        {
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done = false;
        }

        //ELSE IF it was shrinking for to long and minWidth has been exceeded 
        else if (isInside && currentSize.x.Equals(minWidth - 0.2f))
        {
            Debug.Log("Didn't press for too long! (I can't breathe like this)");
            //Turn renderer of tuning system off
            GameObject.Find("Sign").GetComponent<SignInteraction>().tuning.SetActive(false);
            //Start animation of fuzzy object
            animator.SetBool("clear", true);
            //Turn of fuzzy sound
            emitter.enabled = false;
            //Trigger dialogue
            GetComponent<ConversationTrigger>().TriggerDialogue();
            oldCamera.enabled = true;
            currentCamera.enabled = false;
        }

        //ELSE IF minWidth is reached and it's still shrinking
        else if (isInside && currentSize.x <= minWidth)
        {
            Debug.Log("I need to Breathe in!");

            //Starting to shake
            gameObject.transform.position = new Vector2(startX + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, startY + Mathf.Sin(Time.time * shakeSpeed) * shakeAmount);

            //Still shrinks
            if (amount >= 0)
            {
                Debug.Log("Breathing out!2");
                //Increments amount based on Time.deltaTime multiplied by speed
                amount -= Time.deltaTime * (speed - 0.1f);
                srenderer.size = new Vector2(Mathf.Lerp(minWidth - 0.2f, maxWidth + 0.5f, amount), 0.2f);
                currentSize = srenderer.size;
            }

            //Shaking harder
            shakeSpeed += 50;
            shakeAmount += 0.0001f;
        }

        //ELSE IF I isn't pressed anymore
        else if (isInside)
        { 
            //Move bar from outside to inside 
            if (amount < 1 && amount >= 0)
            {
                Debug.Log("Simply Breathing out!");
                //Increments amount based on Time.deltaTime multiplied by speed
                amount -= Time.deltaTime * speed;
                srenderer.size = new Vector2(Mathf.Lerp(minWidth - 0.2f, maxWidth + 0.5f, amount), 0.2f);
                currentSize = srenderer.size;
                shakeSpeed = 50;
                shakeAmount = 0.0019f;
            }
        }
    }
}    
