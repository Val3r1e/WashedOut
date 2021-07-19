using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMODUnity;

public class Gate : MonoBehaviour
{
    //Cameras
    public GameObject virtualCamera;
    public GameObject virtualCameraZoomedIn;
    CinemachineVirtualCamera currentCamera;
    CinemachineVirtualCamera zoomedInCamera;

    //BoxAnchor
    public GameObject boxAnchor;
    Vector3 oldBoxPos;

    bool wasTriggered = false;
    bool done = false;
    bool waiting = false;

    public Collider2D collider;

    public Animator animator;

    //StudioEventEmitter fuzzy;
    //StudioEventEmitter openingSound;
    public GameObject fuzzy;
    public GameObject gateOpen;
    bool triggerEnter = false;

    private void Start()
    {
        //Get Cameras
        currentCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        zoomedInCamera = virtualCameraZoomedIn.GetComponent<CinemachineVirtualCamera>();

        //Get BoxAnchor's otiginal position
        oldBoxPos = boxAnchor.transform.localPosition;
        
        animator = gameObject.GetComponent<Animator>();

        gateOpen.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            triggerEnter = true;
        }
    }
    
    private void Update()
    {
        if (waiting && !done && GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done)
        {
            //Debug.Log("Gate dialogue done");
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done = false;

            //Turn off fuzzy sound
            fuzzy.SetActive(false);

            //Turn on gate opening sound
            gateOpen.SetActive(true);

            StartCoroutine(OpenGate());

            //Turn of Chromatic Aberration
            GameObject.Find("GrayFilter").GetComponent<PPVaryAberration>().max = 0.3f;

            //return boxAnchor to old position
            boxAnchor.transform.localPosition = oldBoxPos;

            done = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            wasTriggered = true;
            triggerEnter = false;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        //Change cameras - zoom in 
        zoomedInCamera.enabled = true;
        currentCamera.enabled = false;
        
        //Assign position for BoxAnchor when zoomed        
        Vector3 newBoxPos = new Vector3(0.7f, 0.6f, 0.0f);
        boxAnchor.transform.localPosition = newBoxPos;

        yield return new WaitForSeconds(1.9f);

        //Trigger dialogue
        GetComponent<ConversationTrigger>().TriggerDialogue();

        waiting = true;
    }

    IEnumerator OpenGate()
    {
        //Clear Door
        animator.SetBool("Clear", true);
        yield return new WaitForSeconds(1f);

        //Open Door
        animator.SetBool("Open", true);

        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        //Disable collider 
        collider.enabled = false;

        //Change cameras - zoom out 
        currentCamera.enabled = true;
        zoomedInCamera.enabled = false;
    }

    void OnTriggerExit2D(Collider2D c)
    {
        triggerEnter = false;
    }
}
