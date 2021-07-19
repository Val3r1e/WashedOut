using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkNight : MonoBehaviour
{
    bool triggered = false;
    void Update()
    {
        if(!triggered)
        {
            StartCoroutine(Wait());
            triggered = true;
        } 
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.8f);
        GetComponent<ConversationTrigger>().TriggerDialogue();
    }
}
