using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    public GameObject player;
    Animator PlayerAnimator;
    public string scene;
    bool triggerEnter = false;
    bool wasTriggered = false;

    void Start()
    {
        PlayerAnimator = player.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            triggerEnter = true;
        }
    }

    void Update()
    {
        //If "E" was pressed 
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            triggerEnter = false;
            wasTriggered = true;

            //Freeze player
            player.GetComponent<PlayerMovement>().isFrozen = true;

            //Start animation & make player disappear
            PlayerAnimator.SetBool("entered", true);

            StartCoroutine(Wait());            
        }
    }

    IEnumerator Wait()
    {
        //Wait for animation to finish
        yield return new WaitForSeconds(0.7f);

        Initiate.Fade(scene, Color.black, 1.5f);
    }

    void OnTriggerExit2D(Collider2D c)
    {
        triggerEnter = false;
    }
}
