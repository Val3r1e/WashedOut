using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class CloudScript : MonoBehaviour {

    public GameObject cloudManager;
    //Set these variables to whatever you want the slowest and fastest speed for the clouds to be, through the inspector.
    //If you don't want clouds to have randomized speed, just set both of these to the same number.
    //For Example, I have these set to 2 and 5
    public float minSpeed;
    public float maxSpeed;
 
    //Set these variables to the lowest and highest y values you want clouds to spawn at.
    //For Example, I have these set to 1 and 4
    public float minY;
    public float maxY;
 
    //Set this variable to how far off screen you want the cloud to spawn, and how far off the screen you want the cloud to be for it to despawn. You probably want this value to be greater than or equal to half the width of your cloud.
    //For Example, I have this set to 4, which should be more than enough for any cloud.
    public float buffer;
 
    float speed;
    float camWidth;
 
    void Start() {
        //check if the first clouds have spawned
        cloudManager = GameObject.Find("CloudManager");
        bool hasSpawned = cloudManager.GetComponent<CloudManagerScript>().hasSpawned;

        speed = Random.Range(minSpeed, maxSpeed);
 
        CloudPos(hasSpawned);
    }
 
    // Update is called once per frame
    void Update() {
        //Translates the cloud to the right at the speed that is selected
        transform.Translate(speed * Time.deltaTime, 0, 0);
        //If cloud is off Screen, Destroy it.
        if(transform.position.x > -9) {
            Destroy(gameObject);
        }
    }

    void CloudPos(bool hasSpawned){
        if (hasSpawned == false){

            //if these are the first clouds, spawn anywhere on screen
            transform.position = new Vector3(Random.Range(-18.5f, -11f), Random.Range(minY, maxY), transform.position.z);

        } else {

            //if these are not the first clouds, spawn from out of the screen
            transform.position = new Vector3(-18.5f, Random.Range(minY, maxY), transform.position.z);

        }

    }
}