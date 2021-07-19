using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public string scene;

    void OnTriggerEnter2D(Collider2D c)
    {
        Initiate.Fade(scene, Color.black, 0.7f);
    }
}
