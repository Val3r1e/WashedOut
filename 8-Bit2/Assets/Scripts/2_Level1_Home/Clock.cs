using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public SpriteRenderer instruction;
    public CircleCollider2D trigger;

    public bool wasTriggered = false;
    bool triggerEnter = false;

    void Start()
    {
        instruction.enabled = false;
        trigger.enabled = false;
    }

    void Update()
    {
        if (GameObject.Find("Computer").GetComponent<TurnOn>().wasTriggered)
        {
            trigger.enabled = true;
        }
        //If "E" was pressed 
        if (!wasTriggered && Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            StartCoroutine(Wait());
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (!wasTriggered)
        {
            instruction.enabled = true;
            triggerEnter = true;
        }
    }

    IEnumerator Wait()
    {
        wasTriggered = true;
        instruction.enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<ConversationTrigger>().TriggerDialogue();
    }
    
    void OnTriggerExit2D(Collider2D c)
    {
        instruction.enabled = false;
        triggerEnter = false;
    }
}
