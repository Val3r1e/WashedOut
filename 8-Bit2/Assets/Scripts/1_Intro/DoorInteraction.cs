using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{

    public GameObject player;
    public SpriteRenderer instruction;

    Animator PlayerAnimator;
    bool triggerEnter = false;

    void Start()
    {
        PlayerAnimator = player.GetComponent<Animator>();
        instruction.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //If the door is active
        if (gameObject.activeSelf)
        {
            //Show instructions
            instruction.enabled = true;
            triggerEnter = true;
        }
    }

    void Update()
    {
        //If "E" was pressed 
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            //Don't show instructions
            instruction.enabled = false;

            //Start animation & make player disappear
            PlayerAnimator.SetBool("entered", true);

            //Fade into next scene
            Initiate.Fade("Level1_Home", Color.black, 0.5f);
            triggerEnter = false;
        }
    }

    /*IEnumerator*/ /*void OnTriggerStay2D(Collider2D c)
    {
        //If "E" was pressed 
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Don't show instructions
            instruction.enabled = false;

            //Start animation & make player disappear
            PlayerAnimator.SetBool("entered", true);

            //Fade into next scene
            Initiate.Fade("Level1_Home", Color.black, 0.5f);
        }
    }*/

    void OnTriggerExit2D(Collider2D c)
    {
        //Don't show instructions
        instruction.enabled = false;
        triggerEnter = false;
    }
}
