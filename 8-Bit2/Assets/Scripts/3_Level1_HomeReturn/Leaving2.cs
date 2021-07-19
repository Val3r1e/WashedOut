using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaving2: MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D c)
    {
        SceneManager.LoadScene("Level1_Connected");
    }
}
