using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class ClampBox : MonoBehaviour
{

	public GameObject dialogueBox;
    public Camera camera;

    // Update is called once per frame
    void Update()
    {

        Vector3 boxPos = camera.WorldToScreenPoint(this.transform.position);
        dialogueBox.transform.position = boxPos;
    }
}
