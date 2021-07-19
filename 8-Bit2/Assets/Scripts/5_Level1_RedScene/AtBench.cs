using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using FMODUnity;

public class AtBench : MonoBehaviour
{
    //Objects
    public GameObject clouds;
    public GameObject sun;

    //Mark
    public GameObject mark;
    Animator animator;
    Animator animatorM;
    StudioEventEmitter music;

    //Cameras
    public GameObject virtualCamera;
    public GameObject virtualCameraZoomedOut;
    public GameObject virtualCameraZoomedIn;
    CinemachineVirtualCamera currentCamera;
    CinemachineVirtualCamera newCamera;
    CinemachineVirtualCamera lastCamera;

    //Al
    float amount = 0;
    float startPosition = 0;
    float speed = 0.16f;
    public GameObject player;
    Animator panimator;

    bool isTriggered = false;
    bool sunsetDone = false;
    bool markDone = false;

    ConversationTrigger markDialogue;

    public ConversationManager conversationM;
    //public DialogueManager manager;

    //Next scene
    public string scene;

    public bool sunsetStart = false;

    private FMOD.Studio.EventInstance instance;

    //[FMODUnity.EventRef]
    //public string fmodEvent;

    // Start is called before the first frame update
    void Start()
    {
        //Get Animators
        animator = clouds.GetComponent<Animator>();
        animatorM = mark.GetComponent<Animator>();
        panimator = player.GetComponent<Animator>();

        //Get Cameras
        currentCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();
        newCamera = virtualCameraZoomedOut.GetComponent<CinemachineVirtualCamera>();
        lastCamera = virtualCameraZoomedIn.GetComponent<CinemachineVirtualCamera>();

        //Turn on manual movement
        player.GetComponent<PlayerMovement>().manualMovement = true;

        //Get start position of player
        startPosition = player.transform.position.x;

        //Get components from Mark
        music = mark.GetComponent<StudioEventEmitter>();
        music.enabled = false;
        markDialogue = mark.GetComponent<ConversationTrigger>();

        //instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        //instance.start();
    }

    IEnumerator OnTriggerEnter2D(Collider2D c)
    {
        if (!isTriggered)
        {
            //Move marks arm
            animatorM.SetBool("movingArm", true);
            //Wait
            yield return new WaitForSeconds(0.5f);
            //Start dialogue
            GetComponent<ConversationTrigger>().TriggerDialogue();
            //Triggered is true
            isTriggered = true;
        }
    }

    void Update()
    {
        //Move character from beginning to bench
        if (amount < 1)
        {
            //Walking Sound
            player.GetComponent<PlayerMovement>().playerismoving = true;
            //Walking Animation
            panimator.SetFloat("Speed", 1);
            panimator.SetFloat("Direction", 1);
            //Walking Movement
            amount += Time.deltaTime * speed; 
            player.transform.position = new Vector3(Mathf.Lerp(startPosition, -1.45f, amount), player.transform.position.y, player.transform.position.z);
        }
        else if (amount.Equals(1))
        {
            //Turn of walking sound
            player.GetComponent<PlayerMovement>().playerismoving = false;
            //Walking Animation
            panimator.SetFloat("Speed", 0);
            panimator.SetFloat("Direction", 0);
        }
        //Change camera to view sunset
        else if (!sunsetDone && conversationM.GetComponent<ConversationManager>().done)
        {
            conversationM.GetComponent<ConversationManager>().done = false;

            //Make Al sit down! Animation!
            panimator.SetBool("sitting", true);

            //Start sunset animation
            StartCoroutine(PlayAnimation());


            sunsetDone = true;
        }
        //Load dream scene
        else if(sunsetDone && !markDone && conversationM.GetComponent<ConversationManager>().done)
        {
            markDone = true;

            //Switch cameras
            //lastCamera.enabled = true;
            //newCamera.enabled = false;

            Initiate.Fade(scene, Color.black, 0.2f);
        }
    }

    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        //Turn on music
        music.enabled = true;

        //Switch cameras
        newCamera.enabled = true;
        currentCamera.enabled = false;

        yield return new WaitForSeconds(0.5f);

        //Start sunset animation
        animator.SetBool("atBench", true);
        clouds.SetActive(true);
        //sun.SetActive(true);
        sun.GetComponent<SunMovement>().moveSun = true;

        //Make it more colorful!
        sunsetStart = true;

        //Wait for animation to finish
        yield return new WaitForSeconds(13f);

        //instance.setParameterByName("General Fade Out", 1);

        markDialogue.TriggerDialogue();

        yield return null;
    }
}
