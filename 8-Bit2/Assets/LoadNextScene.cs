using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string scene;
    void OnTriggerEnter2D(Collider2D c)
    {
        SceneManager.LoadScene(scene);
    }
}
