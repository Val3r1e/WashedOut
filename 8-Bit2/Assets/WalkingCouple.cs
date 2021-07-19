using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCouple : MonoBehaviour
{
    public bool wasTriggered = false;
    bool waiting = false;

    //Couple
    public GameObject Jane;
    public GameObject Rosa;
    Animator janeAnimator;
    Animator rosaAnimator;

    //Walking
    float amount = 0;
    float startPosition = 0;
    public float speed = 0.02f;
    public float endPosition = 19.49f;

    //Collider
    public Collider2D collider;

    void Start()
    {
        janeAnimator = Jane.GetComponent<Animator>();
        rosaAnimator = Rosa.GetComponent<Animator>();

        //Get start position
        startPosition = gameObject.transform.position.x;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (!wasTriggered)
        {
            wasTriggered = true;
            GetComponent<ConversationTrigger>().TriggerDialogue();
            waiting = true;

            janeAnimator.SetBool("Standing",true);
            rosaAnimator.SetBool("Standing",true);
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (waiting && GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done)
        {
            Debug.Log("couple dialogue done");
            GameObject.Find("ConversationManager").GetComponent<ConversationManager>().done = false;
            waiting = false;
        }
    }

    void Update()
    {
        if(!waiting)
        {
            //Move character from beginning to target
            if (amount < 1)
            {
                janeAnimator.SetBool("Standing",false);
                rosaAnimator.SetBool("Standing",false);

                amount += Time.deltaTime * speed; 
                gameObject.transform.position = new Vector3(Mathf.Lerp(startPosition, endPosition, amount), gameObject.transform.position.y, gameObject.transform.position.z);

                if(gameObject.transform.position.x >= 20)
                {
                    collider.enabled = false;
                }
            }
            else{
                janeAnimator.SetBool("Standing",true);
                rosaAnimator.SetBool("Standing",true);
            }
        }
    }
}
