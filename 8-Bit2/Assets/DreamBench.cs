using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DreamBench : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    Animator benchAnimator;
    public GameObject sittingPlayer;
    public StudioEventEmitter benchGoingDown;

    void Start()
    {
        player.GetComponent<PlayerMovement>().isFrozen = true;
        animator = player.GetComponent<Animator>();
        animator.SetBool("sitting", true); 
        benchAnimator = gameObject.GetComponent<Animator>();
        player.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        player.GetComponent<SpriteRenderer>().enabled = true;
        sittingPlayer.SetActive(false);
        animator.SetBool("sitting", false);
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerMovement>().isFrozen = false;
        animator.SetBool("normal", true);
        benchAnimator.SetBool("down",true);
        benchGoingDown.Play();
    }
}
