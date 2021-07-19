using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arriving : MonoBehaviour
{
    public Renderer arrowKeys;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Disable canvas
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        arrowKeys.enabled = false;
    }
}
