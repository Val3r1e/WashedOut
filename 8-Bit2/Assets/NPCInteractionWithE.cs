using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractionWithE : MonoBehaviour
{
    public bool wasTriggered = false;
    bool waiting = false;
    public SpriteRenderer instruction;
    public bool turnOnAberration = false;
    bool triggerEnter = false;

    void Start()
    {
        instruction.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            instruction.enabled = true;
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
            instruction.enabled = false;
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
        instruction.enabled = false;
        triggerEnter = false;
    }
}
