using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackgroundLoop : MonoBehaviour
{
    public float minY = -3.5f;
    public float maxY = 3.5f;

    [SerializeField] [Range(-1f, 1f)] float speed = 0.75f;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, speed * Time.deltaTime, 0);

        if(speed < 0) {

        	if(transform.localPosition.y <= minY){
            
            transform.localPosition = new Vector3(0, maxY, 0);

       		}

        } else if (speed >= 0) {

        	if(transform.localPosition.y >= maxY){
            
            transform.localPosition = new Vector3(0, minY, 0);

       		}
        }


        


    }
}
