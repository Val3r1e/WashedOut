using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class CloudManagerScene : MonoBehaviour {
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
        Instantiate(cloudPrefab, transform);
        Instantiate(cloudPrefab2, transform);
        Instantiate(cloudPrefab3, transform);
        Instantiate(cloudPrefab4, transform);
        Instantiate(cloudPrefab5, transform);
        Instantiate(cloudPrefab6, transform);

        StartCoroutine(SpawnClouds());

    }

    void Update(){

    }
 
    IEnumerator SpawnClouds() {
        //This will always run
        	while(true) {
            	//Only spawn clouds if the boolean spawnClouds is true
            	while(spawnClouds) {
            	    //Instantiate Cloud Prefab and then wait for specified delay, and then repeat
                        
                		yield return new WaitForSeconds(15);
                		hasSpawned = true;
                		//Debug.Log(spawnClouds);
                       

                		Instantiate(cloudPrefab, transform);
                        yield return new WaitForSeconds(3);
                        if(Random.value > 0.5) {
                        	Instantiate(cloudPrefab6, transform);
                        }
                		yield return new WaitForSeconds(delay);

                		Instantiate(cloudPrefab2, transform);
                        yield return new WaitForSeconds(3);
                        if(Random.value > 0.5) {
                        	Instantiate(cloudPrefab4, transform);
                        }
                		yield return new WaitForSeconds(delay);


                		Instantiate(cloudPrefab3, transform);
                        yield return new WaitForSeconds(3);
                        if(Random.value > 0.5) {
                        	Instantiate(cloudPrefab5, transform);
                        }
                		yield return new WaitForSeconds(delay);
            	
        	}
    	}
	}
}