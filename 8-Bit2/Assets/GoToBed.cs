using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBed : MonoBehaviour
{
    bool wasTriggered = false;
    public string scene;
    
    void OnTriggerStay2D(Collider2D c)
    {
        if (!wasTriggered && Input.GetKeyDown(KeyCode.E))
        {
            wasTriggered = true;

            Initiate.Fade(scene, Color.black, 0.7f);
        }
    }
}
