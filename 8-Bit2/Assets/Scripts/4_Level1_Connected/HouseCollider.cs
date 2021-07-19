using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseCollider : MonoBehaviour
{
    float amount = 0;
    float startPositionX = 0;
    float startPositionY = 0;
    float speed = 1f;
    public GameObject player;
    Animator animator; 
    bool enter = false;

    public Collider2D col;
    bool triggerEnter = false;
    bool wasTriggered = false;

    void Start()
    {
        col.enabled = false;

        animator = player.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(!wasTriggered){
            triggerEnter = true;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && triggerEnter)
        {
            triggerEnter = false;
            wasTriggered = true;
            
            //Start position player
            startPositionX = player.transform.position.x;
            startPositionY = player.transform.position.y;
            
            enter = true;
        }
        if (enter)
        {
            //Turn on manual movement
            player.GetComponent<PlayerMovement>().manualMovement = true;

            //Move character up to house entrance
            if (amount < 1)
            {
                //Walking Sound
                player.GetComponent<PlayerMovement>().playerismoving = true;
                //Walking Animation
                animator.SetFloat("Speed", 1f);
                animator.SetFloat("Direction", -1f);
                //Movement 
                amount += Time.deltaTime * speed;
                player.transform.position = new Vector3(Mathf.Lerp(startPositionX, -0.99f, amount), Mathf.Lerp(startPositionY, -0.18f, amount), player.transform.position.z);
                //Enable floor
                col.enabled = true;
            }
            else
            {
                //Enable floor
                col.enabled = true;
                player.GetComponent<SpriteRenderer>().enabled = false;
                Initiate.Fade("Level2_HomeMorning", Color.black, 0.2f);
                //SceneManager.LoadScene("Level2_HomeMorning");
            }
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        triggerEnter = false;
    }
}
