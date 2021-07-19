using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MoveInTitle : MonoBehaviour
{
    public UnityEngine.UI.Button play;
    public UnityEngine.UI.Button quit;
    public StudioEventEmitter sound;

    void Start()
    {
        play.Select();
        play.OnSelect(null);
    }

    /*void OnEnable()
    {
        resume.Select();
        resume.OnSelect(null);
    }*/

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            sound.Play();
            quit.Select(); 
            quit.OnSelect(null);
            //sound.Stop();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            sound.Play();
            play.Select();
            play.OnSelect(null);
            //sound.Stop();
        } 
    }
}
