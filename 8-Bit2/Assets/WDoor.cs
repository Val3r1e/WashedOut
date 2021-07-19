using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WDoor : MonoBehaviour
{
    public GameObject player;
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        player.SetActive(false);
        StartCoroutine(WaitPlayer());
    }

    IEnumerator WaitPlayer()
    {
        yield return new WaitForSeconds(2f);
        player.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("done",true);
    }
}
