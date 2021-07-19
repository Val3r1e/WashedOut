using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDialogue : MonoBehaviour
{
    public UnityEngine.UI.Button contin;

    void Start()
    {
        contin.Select();
    }

    /*void OnEnable()
    {
        contin.Select();
        contin.OnSelect(null);
    }*/

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            contin.Select();
        }
    }
}
