using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock2 : MonoBehaviour
{
    bool wasTriggered = false;

    void OnTriggerStay2D(Collider2D c)
    {
        //If "E" was pressed 
        if (!wasTriggered && Input.GetKeyDown(KeyCode.E))
        {
            wasTriggered = true;
            GetComponent<ConversationTrigger>().TriggerDialogue();
        }
    }

}
