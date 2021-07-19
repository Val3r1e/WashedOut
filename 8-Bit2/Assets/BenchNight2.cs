using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchNight2 : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    public GameObject sittingPlayer;
    bool dialogueDone = false;

    void Start()
    {
        //player.GetComponent<PlayerMovement>().isFrozen = true;
        animator = player.GetComponent<Animator>();
        animator.SetBool("sitting", true); 
        player.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        if (GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done)
        {
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done = false;
            player.GetComponent<PlayerMovement>().isFrozen = true;
            dialogueDone = true;
        }
        if(dialogueDone && Input.GetKeyDown(KeyCode.E))
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
    }
}
