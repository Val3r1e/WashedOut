using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using Cinemachine;

public class PixelCollection : MonoBehaviour
{
    //Cameras
    public GameObject currentVirtualCamera;
    public GameObject newVirtualCamera;
    CinemachineVirtualCamera currentCamera;
    CinemachineVirtualCamera newCamera;

    //Pixel light
    public Light2D pointLight;
    public ParticleSystem cone;
    public ParticleSystem pixel;

    //Next scene
    public string scene;
    bool triggerEnter = false;
    bool wasTriggered = false;

    void Start()
    {
        //Get Cameras
        currentCamera = currentVirtualCamera.GetComponent<CinemachineVirtualCamera>();
        newCamera = newVirtualCamera.GetComponent<CinemachineVirtualCamera>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            triggerEnter = true;
        }
    }

    void Update()
    {
        //If "E" was pressed 
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            triggerEnter = false;
            wasTriggered = true;

            //Switch cameras
            newCamera.enabled = true;
            currentCamera.enabled = false;

            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(7f);

        //Make pixel disappear
        gameObject.SetActive(false);
        pointLight.enabled = false; 
        cone.Stop();
        pixel.Stop();

        Initiate.Fade(scene, Color.black, 0.7f);
    }

    void OnTriggerExit2D(Collider2D c)
    {
        triggerEnter = false;
    }
}
