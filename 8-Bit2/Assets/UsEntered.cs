using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UsEntered : MonoBehaviour
{
    public bool wasTriggered = false;
    bool waiting = false;
    public string scene;
    public GameObject player;
    public GameObject radio;

    //Cameras
    public GameObject virtualCamera;
    public GameObject virtualCameraZoomedIn;
    CinemachineVirtualCamera currentCamera;
    CinemachineVirtualCamera newCamera;

    //Canvas
    public GameObject canvas;

    void Start()
    {
        //Get Cameras
        currentCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        newCamera = virtualCameraZoomedIn.GetComponent<CinemachineVirtualCamera>();

        canvas.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D c)
    {
        if (!wasTriggered)
        {
            wasTriggered = true;
            //StartCoroutine(Wait());
            waiting = true;
            player.GetComponent<PlayerMovement>().isFrozen = true;
            GetComponent<ConversationTrigger>().TriggerDialogue();
        }
    }

    /*IEnumerator Wait()
    {
        //Switch cameras
        newCamera.enabled = true;
        currentCamera.enabled = false;

        yield return new WaitForSeconds(1f);

        GetComponent<ConversationTrigger>().TriggerDialogue();
    }*/

    IEnumerator OnTriggerStay2D(Collider2D c)
    {
        if (waiting && GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done)
        {
            Debug.Log("couple dialogue done");
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done = false;
            waiting = false;

            player.GetComponent<PlayerMovement>().isFrozen = true;

            //THANK YOU FOR PLAYING
            canvas.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            //Switch cameras
            newCamera.enabled = true;
            currentCamera.enabled = false;

            yield return new WaitForSeconds(4f);

            //Fade out
            Initiate.Fade(scene, Color.black, 0.3f);
        }
    }
}
