using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public string scene;
    public float waitFor = 4f;

    void Start()
    {
        StartCoroutine(CallNext());
    }

    IEnumerator CallNext()
    {
        yield return new WaitForSeconds(waitFor);
        Initiate.Fade(scene, Color.black, 0.7f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
