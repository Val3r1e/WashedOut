using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenchNight : MonoBehaviour
{
    bool triggered = false;
    public string scene;

    public GameObject player;

    void Start()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        if(!triggered)
        {
            GetComponent<ConversationTrigger>().TriggerDialogue();
            triggered = true;
            StartCoroutine(Wait());
        }   
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        Initiate.Fade(scene, Color.black, 0.7f);
    }
}
