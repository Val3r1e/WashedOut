using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //UI NPCText 
    public TextMeshProUGUI nameText;
    //UI DialogueText
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    public bool done = false;

    public GameObject dialogueCanvas;

    //Private queue of sentences
    Queue<string> sentencesq;

    void Start()
    {
        done = false;
        //Initialize Queue of strings used for storing the sentences
        sentencesq = new Queue<string>();

        dialogueCanvas.SetActive(false);
    }

    //Start the dialogue, is called in DialogueTrigger with dialogue created in unity
    public void StartDialogue(Dialogue dialogue){

        //Freeze player
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = true;

        dialogueCanvas.SetActive(true);

        //Move dialogue box into scene
        animator.SetBool("isOpen", true);

        //Store name in NPCText UI
        nameText.text = dialogue.name;

        //Clear all old sentences still in queue
        sentencesq.Clear();

        //For each sentence in sentences 
        foreach (string sent in dialogue.sentences){

            //Put it into queue
            sentencesq.Enqueue(sent);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){

        if(sentencesq.Count == 0){  

            //Move dialogue box out of scene
            animator.SetBool("isOpen", false);

            //Unfreeze player
            GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = false;

            //Set dialogue as done
            done = true;
            //dialogueCanvas.SetActive(false);
        }
        else
        {
            StopAllCoroutines();        ///Problem is here!!
            StartCoroutine(TypeSentence(sentencesq.Dequeue()));
        }
    }

    IEnumerator TypeSentence(string sent)
    {
        dialogueText.text = "";

        foreach(char letter in sent.ToCharArray())
        {
            dialogueText.text += letter;

            yield return null;
        }
    }
}
