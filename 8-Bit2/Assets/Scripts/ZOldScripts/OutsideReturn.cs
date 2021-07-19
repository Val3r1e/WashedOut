using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideReturn : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        SceneManager.LoadScene("Level1_OutsideReturn");

    }
}
