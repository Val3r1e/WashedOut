using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInMenu : MonoBehaviour
{
    public UnityEngine.UI.Button resume;
    public UnityEngine.UI.Button quit;

    void Start()
    {
        resume.Select();
        resume.OnSelect(null);
    }

    void OnEnable()
    {
        resume.Select();
        resume.OnSelect(null);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            quit.Select(); 
            quit.OnSelect(null);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            resume.Select();
            resume.OnSelect(null);
        } 
    }
}
