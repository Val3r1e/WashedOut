using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaving : MonoBehaviour
{
    public BoxCollider2D bCollider;

    void Update()
    {
        if (GameObject.Find("Clock").GetComponent<Clock>().wasTriggered)
        {
            //Disable collider
            bCollider.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
