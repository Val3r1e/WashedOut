using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class CloudScriptScene : MonoBehaviour {

    //initial position
    private float startPos;
    
    //cloudmanager object
    public GameObject cloudManager;

    //minimum and maximum speed
    public float minSpeed;
    public float maxSpeed;
 
    //minimum and maximum height
    public float minY;
    public float maxY;
 
    //how far off the screen clouds can be
    public float buffer;

    //cloud movement speed and background width
    float speed;
    float sceneWidth;
 
    void Start() {

        //get variables from cloud manager
        cloudManager = GameObject.Find("CompleteOutside-02");
        bool hasSpawned = cloudManager.GetComponent<CloudManagerScene>().hasSpawned;

        //define the background size
        sceneWidth = cloudManager.GetComponent<SpriteRenderer>().bounds.size.x;

        //spawn on a random position if these are the first clouds, if not, spawn from beginning
        if (hasSpawned == true){
            startPos = -sceneWidth/2;

        } else {
            startPos = Random.Range(-sceneWidth/2, 0);

        }
 
        //set cloud movement speed
        speed = Random.Range(minSpeed, maxSpeed);

        //set starting position
        transform.localPosition = new Vector3(startPos, Random.Range(minY, maxY), transform.position.z);
    }
 
    // Update is called once per frame
    void Update() {
        //move clouds respecting parallax movement
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
        //If cloud is off scene, Destroy it.
        if(transform.localPosition.x > sceneWidth/2 + buffer) {
            Destroy(gameObject);
        }
    }
}
