using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class WakingUp2 : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    Renderer rend;
    public StudioEventEmitter alarmSound;

    public GameObject clock;
    Animator clockAnimator;

    void Start()
    {
        //Make player invisible 
        rend = player.GetComponent<Renderer>();
        rend.enabled = false;
        //Stop player movement
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = true;

        clockAnimator = clock.GetComponent<Animator>();
        alarmSound.enabled = false;
        clockAnimator.SetBool("RingingStopped", true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Start wufb animation 
            animator.SetBool("WakingUp", true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.5f);
        animator.SetBool("WakingUp", false);
        rend.enabled = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = false;
    }
}
