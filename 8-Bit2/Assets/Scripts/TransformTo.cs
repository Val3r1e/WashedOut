using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class TransformTo : MonoBehaviour
{

    public GameObject target;
    Vector3 targetCoordinates = new Vector3(0,0,0);
    public GameObject player;
    Animator PlayerAnimator;

    //Cameras
    public GameObject currentVirtualCamera;
    public GameObject newVirtualCamera;
    CinemachineVirtualCamera currentCamera;
    CinemachineVirtualCamera newCamera;
    bool triggerEnter = false;

    void Start()
    {
        PlayerAnimator = player.GetComponent<Animator>();

        //Get Cameras
        currentCamera = currentVirtualCamera.GetComponent<CinemachineVirtualCamera>();
        newCamera = newVirtualCamera.GetComponent<CinemachineVirtualCamera>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        triggerEnter = true;
    }

    void Update()
    {
        targetCoordinates = target.transform.position;

        //If "E" was pressed 
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            triggerEnter = false;
            
            //Freeze player
            player.GetComponent<PlayerMovement>().isFrozen = true;

            //Start animation & make player disappear
            PlayerAnimator.SetBool("entered", true);

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        //Wait for animation to finish
        yield return new WaitForSeconds(0.7f);

        //Switch cameras
        newCamera.enabled = true;
        currentCamera.enabled = false;

        //Transform player
        player.transform.position = targetCoordinates; 

        //Unfreeze player
        player.GetComponent<PlayerMovement>().isFrozen = false;

        //Make player appear 
        PlayerAnimator.SetBool("entered", false);
    }

    void OnTriggerExit2D(Collider2D c)
    {
        triggerEnter = false;
    }
}
