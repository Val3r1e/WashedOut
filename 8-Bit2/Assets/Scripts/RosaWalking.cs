using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosaWalking : MonoBehaviour
{
    float amount = 0;
    float startPosition = 0;
    public float speed = 0.02f;

    public float endPosition = 19.49f;

    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //Get start position
        startPosition = gameObject.transform.position.x;
    }

    void Update()
    {
        //Move character from beginning to target
        if (amount < 1)
        {
            amount += Time.deltaTime * speed; 
            gameObject.transform.position = new Vector3(Mathf.Lerp(startPosition, endPosition, amount), gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else{
            animator.SetBool("Standing",true);
        }
    }
}
