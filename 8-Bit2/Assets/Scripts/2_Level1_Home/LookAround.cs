using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{

    bool triggered = false;

    void OnTriggerStay2D(Collider2D c)
    {
        if (!triggered && !GameObject.Find("Clock").GetComponent<Clock>().wasTriggered && Input.GetKeyDown(KeyCode.E))
        {
            triggered = true;
            GetComponent<ConversationTrigger>().TriggerDialogue();
        }
    }
}
