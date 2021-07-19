using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class RedSceneCloudMovement : MonoBehaviour {

    public float speed;
 
    void Update() {

        if(transform.localPosition.x >= 0 && transform.localPosition.x <= 1.2){
            transform.Translate(speed * Time.deltaTime, 0, 0);

        }

    }
}