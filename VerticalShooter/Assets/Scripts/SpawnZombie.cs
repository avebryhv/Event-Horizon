using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour {

    public GameObject zombiePrefab;
    public Transform zombieSpawn;
    public float spawnTime = 4.0f;
    private int timer = 0;
    private bool isSpawning = false;

    

    // Use this for initialization
    void Start () {
		
	}

    void SetSpawning() {
        isSpawning = false;
    }

	// Update is called once per frame
	void Update () {

        
            if (!isSpawning)
            {
                CreateZombie();
            }
        

    }

    void CreateZombie () {
        isSpawning = true;
        Vector3 temp;       

        temp = new Vector3(Random.Range(-2.5f, 2.5f), 6f, 0);
                
        transform.position = temp;

        Instantiate(zombiePrefab, zombieSpawn.position, zombieSpawn.rotation);

        Invoke("SetSpawning", spawnTime);
    }
}
