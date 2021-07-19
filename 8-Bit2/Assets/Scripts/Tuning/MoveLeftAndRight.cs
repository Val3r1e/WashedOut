using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Cinemachine;

public class MoveLeftAndRight : MonoBehaviour
{
    //Speed of movement
    public float speed = 1.0f;
    public SpriteRenderer instruction;
    //Fuzzy Object
    public GameObject tuningObject;

    //Cameras
    public GameObject virtualCamera;
    public GameObject virtualCameraZoomedIn;
    CinemachineVirtualCamera currentCamera;
    CinemachineVirtualCamera oldCamera;

    //Start position
    private Vector3 pos1 = new Vector3(0f, -1.08f, 0);
    //End position 
    private Vector3 pos2 = new Vector3(1.08f, -1.08f, 0);
    //Wether it was correctly triggered
    bool wasTriggered = false;
    //Keep track of marker and wether it's inside
    bool inside = false;
    //Animator of fuzzy object
    Animator animator;
    //Fuzzy sound
    StudioEventEmitter emitter;

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
    }

    void Update()
    {
        //PingPong approach
        //transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));

        //Sinus approach
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);

        //If marker not inside collider
        if(!inside && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("WRONG!");
            /*float startTime = Time.time;
            while (Time.time < startTime +10)
            {
                transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(10 * Time.time) + 1.0f) / 2.0f);
            }*/
            //Speed up the movement 
            //speed += 0.5f;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //If it's not correctly clicked yet       
        if (!wasTriggered)
        {
            //Show instructions
            instruction.enabled = true;
        }
        //Marker is inside
        inside = true;
    }

    void OnTriggerStay2D(Collider2D c)
    {
        //If "I" was pressed while inside the collider
        if (Input.GetKeyDown(KeyCode.E))
        {
            //It's correctly triggered  
            wasTriggered = true;
            //Don't show instructions anymore 
            instruction.enabled = false;
            Debug.Log("Right!");
            //Turn renderer of tuning system off
            GameObject.Find("Sign").GetComponent<SignInteraction>().tuning.SetActive(false);
            //Start animation of fuzzy object
            animator.SetBool("clear", true);
            //Turn of fuzzy sound
            emitter.enabled = false;
            //Trigger dialogue
            GetComponent<DialogueTrigger>().TriggerDialogue();

            //if(GameObject.Find("DialogueManager").GetComponent<DialogueManager>().done)
            //{
            //    Debug.Log("Zooming Out");
                oldCamera.enabled = true;
                currentCamera.enabled = false;
            //}
        }
    }


    void OnTriggerExit2D(Collider2D c)
    {
        //Don't show instructions anymore
        instruction.enabled = false;
        //Marker is no longer inside
        inside = false; 
    }
}
