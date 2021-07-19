using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class CloudManagerScript : MonoBehaviour {
    //Set this variable to your Cloud Prefab through the Inspector
    public GameObject cloudPrefab;
    public GameObject cloudPrefab2;
    public GameObject cloudPrefab3;
    public GameObject cloudPrefab4;
    public GameObject cloudPrefab5;
    public GameObject cloudPrefab6;
 
    //Set this variable to how often you want the Cloud Manager to make clouds in seconds.
    public float delay;
 
    //If you ever need the clouds to stop spawning, set this variable to false, by doing: CloudManagerScript.spawnClouds = false;
    public static bool spawnClouds = true;
    public bool hasSpawned = false;
 
    // Use this for initialization
    void Start () {
        //Begin SpawnClouds Coroutine
        Instantiate(cloudPrefab);
        Instantiate(cloudPrefab2);
        Instantiate(cloudPrefab3);
        StartCoroutine(SpawnClouds());

    }
 
    IEnumerator SpawnClouds() {
        //This will always run
        	while(true) {
            	//Only spawn clouds if the boolean spawnClouds is true
            	while(spawnClouds) {
            	    //Instantiate Cloud Prefab and then wait for specified delay, and then repeat
                        
                		yield return new WaitForSeconds(15);
                        hasSpawned = true;

                		Instantiate(cloudPrefab);
                        yield return new WaitForSeconds(3);
                        Instantiate(cloudPrefab6);
                		yield return new WaitForSeconds(delay);

                		Instantiate(cloudPrefab2);
                        yield return new WaitForSeconds(3);
                        Instantiate(cloudPrefab4);
                		yield return new WaitForSeconds(delay);


                		Instantiate(cloudPrefab3);
                        yield return new WaitForSeconds(3);
                        Instantiate(cloudPrefab5);
                		yield return new WaitForSeconds(delay);
            	
        	}
    	}
	}
}