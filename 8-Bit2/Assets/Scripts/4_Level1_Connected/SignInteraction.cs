using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class SignInteraction : MonoBehaviour
{
    public SpriteRenderer instruction;
    public GameObject tuning;

    //Cameras
    public GameObject virtualCamera;
    public GameObject virtualCameraZoomedIn;
    CinemachineVirtualCamera currentCamera;
    CinemachineVirtualCamera newCamera;

    bool wasTriggered = false;
    bool wasTuned = false;

    public Collider2D collider;

    private void Start()
    {
        instruction.enabled = false;
        tuning.SetActive(false);

        //Get Cameras
        currentCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        newCamera = virtualCameraZoomedIn.GetComponent<CinemachineVirtualCamera>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (!wasTriggered)
        {
            instruction.enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (Input.GetKeyDown(KeyCode.E) && !wasTuned)
        {
            GetComponent<ConversationTrigger>().TriggerDialogue();
            wasTriggered = true;
            instruction.enabled = false;
        }
    }

    private void Update()
    {
        if (!wasTuned && GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done)
        {
            //Freeze Player
            GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = true;

            StartCoroutine(Wait());

            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done = false;
        }
    }

    IEnumerator Wait()
    {
        newCamera.enabled = true;
        currentCamera.enabled = false;

        collider.enabled = false;

        yield return new WaitForSeconds(1.9f);

        tuning.SetActive(true);
        wasTuned = true;
    }

    void OnTriggerExit2D(Collider2D c)
    {
        instruction.enabled = false;
    }
}
