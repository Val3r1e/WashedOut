using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public bool wasTriggered = false;
    bool waiting = false;
    public bool turnOnAberration = false;
    bool triggerEnter = false;

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            triggerEnter = true;
        }
    }

    void Update()
    {
        if (waiting && GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done)
        {
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done = false;
            waiting = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            wasTriggered = true;
            StartCoroutine(Wait());
            waiting = true;
            triggerEnter = false;

            if(turnOnAberration)
            {
                //Make Chromatic Aberration more intense
                GameObject.Find("GrayFilter").GetComponent<PPVaryAberration>().max += 0.07f;
            } 
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<ConversationTrigger>().TriggerDialogue();
    }

    void OnTriggerExit2D(Collider2D c)
    {
        triggerEnter = false;
    }
}
