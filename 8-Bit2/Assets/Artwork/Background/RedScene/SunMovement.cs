using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
 
public class SunMovement : MonoBehaviour {

    public float speed;
    public float speedRotate;
    public bool moveSun = false;
    Transform sunChildTransform;

    void Start () {
        sunChildTransform = this.gameObject.transform.GetChild(0);
    }
 
    void Update() {

        if(moveSun == true){
            
            transform.Translate(- transform.up * Time.deltaTime * speed);
            sunChildTransform.transform.Rotate(transform.forward * Time.deltaTime * speedRotate, Space.Self);
        }
   
    }
    
}