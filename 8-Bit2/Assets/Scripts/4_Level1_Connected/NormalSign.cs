using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSign : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("normal", true);
    }

}
