using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

     
    public CharacterMovement controller; 
    public Animator animator;
    public bool isFrozen = false;
    public float speed = 7;
    public bool manualMovement = false;

    //Movement direction
    float horizontalmovement = 0f;

    //Movement sound
    [FMODUnity.EventRef]
    public string inputsound;
    public bool playerismoving;
    public float walkingspeed;

    void Start()
    {
        InvokeRepeating("CallFootsteps", 0, walkingspeed);
    }

    void Update(){	

        //Input of horizontal axis (left key = -1, right key = 1, nothing = 0) 
        horizontalmovement = Input.GetAxisRaw("Horizontal");

        if (!isFrozen && !manualMovement)
        {
            //Turn on movement animation
            animator.SetFloat("Speed", Mathf.Abs(horizontalmovement * speed));
            animator.SetFloat("Direction", horizontalmovement);

            //Movement sound
            if (horizontalmovement >= 0.01f || horizontalmovement <= -0.01f)
            {
                playerismoving = true;
            }
            else if (horizontalmovement.Equals(0))
            {
                playerismoving = false;
            }
        }
        else if (isFrozen)
        {
            //Turn off animations
            animator.SetFloat("Speed", 0);
            animator.SetFloat("Direction", 0);
            //Turn off movement sound
            playerismoving = false;
        }
    }

    void FixedUpdate(){

        if (!isFrozen && !manualMovement)
        { 
            controller.Move(horizontalmovement * speed * Time.fixedDeltaTime);  //Makes movement speed consistent across platforms
        }
    }

    void CallFootsteps()
    {
        if (playerismoving == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(inputsound);
        }
    }

    void OnDisable()
    {
        playerismoving = false;
    }
}
