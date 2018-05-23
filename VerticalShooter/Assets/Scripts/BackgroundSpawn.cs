using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawn : MonoBehaviour {

    public GameObject backPrefab;
    public float spawnTime;
    public float decayTime;
    float countdown;
    float decayRate = 1;
    public Transform spawnPoint;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if(countdown > 0)
        {
            countdown -= decayRate;
        }
        if (countdown <= 0)
        {            
            Spawn();
        }
    }

    void Spawn() {
        countdown = spawnTime * 36;
        GameObject newback = Instantiate(backPrefab, spawnPoint.position, spawnPoint.rotation);
        
         
    }
}
