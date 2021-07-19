using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Sign : MonoBehaviour
{
    //Cameras
    public GameObject virtualCamera;
    public GameObject virtualCameraZoomedIn;
    public GameObject virtualCameraNew;
    CinemachineVirtualCamera currentCamera;
    CinemachineVirtualCamera zoomedInCamera;
    CinemachineVirtualCamera newCamera;

    //BoxAnchor
    public GameObject boxAnchor;
    Vector3 oldBoxPos;
    bool wasTriggered = false;
    bool done = false;
    public Collider2D collider;
    bool signDialogue = false;
    bool triggerEnter = false;

    private void Start()
    {
        //Get Cameras
        currentCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        zoomedInCamera = virtualCameraZoomedIn.GetComponent<CinemachineVirtualCamera>();
        newCamera = virtualCameraNew.GetComponent<CinemachineVirtualCamera>();

        //Get BoxAnchor's otiginal position
        oldBoxPos = boxAnchor.transform.localPosition;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            triggerEnter = true;
        }
    }

    private void Update()
    {
        if (signDialogue && !done && GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done)
        {
            Debug.Log("Zooming out");
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done = false;

            //Change cameras - zoom out 
            newCamera.enabled = true;
            zoomedInCamera.enabled = false;

            //return boxAnchor to old position
            boxAnchor.transform.localPosition = oldBoxPos;

            done = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            wasTriggered = true;
            StartCoroutine(Wait());
            triggerEnter = false;
            collider.enabled = false;
        }
    }

    IEnumerator Wait()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = true;
        //Change cameras - zoom in 
        zoomedInCamera.enabled = true;
        currentCamera.enabled = false;

        //Disable collider 
        collider.enabled = false;

        //Assign position for BoxAnchor when zoomed
        Vector3 newBoxPos = new Vector3(0.7f, 0.6f, 0.0f);
        boxAnchor.transform.localPosition = newBoxPos;

        yield return new WaitForSeconds(1.9f);

        //Trigger dialogue
        GetComponent<ConversationTrigger>().TriggerDialogue();
        signDialogue = true;
    }

    void OnTriggerExit2D(Collider2D c)
    {
        triggerEnter = false;
    }
}
