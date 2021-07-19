using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaneWalking : MonoBehaviour
{
    float amount = 0;
    float startPosition = 0;
    float speed = 1.2f;

    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        startPosition = gameObject.transform.position.x;
    }

    void Update()
    {
        //Move character back and forth 
        gameObject.transform.position = new Vector3(Mathf.Lerp(startPosition, 3.68f, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f), gameObject.transform.position.y, gameObject.transform.position.z);

        if(gameObject.transform.position.x <= 3.251f)
        {
            animator.SetBool("back",false);
        }
        else if(gameObject.transform.position.x >= 3.679f)
        {
            animator.SetBool("back",true);
        }
    }
}
