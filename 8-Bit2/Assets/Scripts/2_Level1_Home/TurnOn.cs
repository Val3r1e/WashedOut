using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TurnOn : MonoBehaviour
{
    public SpriteRenderer instruction;
    public Animator animator;
    public StudioEventEmitter music;
    public StudioEventEmitter tastatur;

    public bool wasTriggered = false;
    bool triggerEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        instruction.enabled = false;
        music.enabled = false;
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
        //If "E" was pressed 
        if(!wasTriggered && Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            tastatur.Play();
            wasTriggered = true;
            instruction.enabled = false;
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
        //Start music
        music.enabled = true;
        GetComponent<ConversationTrigger>().TriggerDialogue();
    }


    void OnTriggerExit2D(Collider2D c)
    {
        instruction.enabled = false;
        triggerEnter = false;
    }
}
