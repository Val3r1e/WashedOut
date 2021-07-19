using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingDown : MonoBehaviour
{
    bool triggerEnter = false;
    bool wasTriggered = false;
    bool satDown = false;
    public GameObject player;
    Animator animator;

    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            Debug.Log("Trigger Enter");
            triggerEnter = true;
        }
    }

    void Update()
    {
        //If "E" was pressed 
        if (Input.GetKeyDown(KeyCode.E) && triggerEnter)
        {
            Debug.Log("First E");
            wasTriggered = true;
            triggerEnter = false;
            animator.SetBool("sitting", true);
            StartCoroutine(Wait());
;        }
        if(Input.GetKeyDown(KeyCode.E) && satDown)
        {
            Debug.Log("Second E");
            animator.SetBool("sitting", false);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        satDown = true;
    }
    void OnTriggerExit2D(Collider2D c)
    {
        Debug.Log("Trigger Exit");
        triggerEnter = false;
    }
}
