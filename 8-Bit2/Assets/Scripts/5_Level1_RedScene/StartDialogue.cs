using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D c)
    {
        //Trigger dialogue
        GetComponent<DialogueTrigger>().TriggerDialogue();
        GameObject.Find("DialogueManager").GetComponent<DialogueManager>().done = false;
    }
}
