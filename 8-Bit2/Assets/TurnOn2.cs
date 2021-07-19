using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TurnOn2 : MonoBehaviour
{
    public Animator animator;
    public StudioEventEmitter tastatur;
    public bool wasTriggered = false;
    bool triggerEnter = false;

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            triggerEnter = true;
        }
    }

    void Update()
    {
        //If "E" was pressed 
        if(Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            tastatur.Play();
            wasTriggered = true;
            triggerEnter = false;
            animator.SetBool("isClicked", true);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        //Freeze player
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = true;
        yield return new WaitForSeconds(2.5f);
        tastatur.Stop();
        //Unfreeze player
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = false;
        GetComponent<ConversationTrigger>().TriggerDialogue();
    }

    void OnTriggerExit2D(Collider2D c)
    {
        triggerEnter = false;
    }
}
