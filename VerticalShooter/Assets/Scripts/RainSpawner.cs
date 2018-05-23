using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public bool isFiring = true;

    public bool gap = false;

    public float gapSpace = 0.6f;
    public float stageLeft = -6;
    public float stageRight = 2;
    public float bulletCount = 8;


    void SetFiring()
    {
        isFiring = false;

    }

    void Fire()
    {
        isFiring = true;
        float tempPos = stageLeft;
        float interval = (stageRight - stageLeft) / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            Vector2 spawnPoint = new Vector2(tempPos, 5);
            Instantiate(bulletPrefab, spawnPoint, bulletSpawn.rotation);
            tempPos += interval;
        }

        Invoke("SetFiring", fireTime);
    }

    void Lasers()
    {
        int rand = Random.Range(7, 20);
        isFiring = true;
        float xPos = -7f;
        for (int i = 0; i < rand; i++)
        {
            Vector2 spawnPoint = new Vector2(xPos, 5);
            Instantiate(bulletPrefab2, spawnPoint, bulletSpawn.rotation);
            xPos += 0.3f;
        }
        xPos += gapSpace;
        for (int i = rand; i < 30; i++)
        {
            Vector2 spawnPoint = new Vector2(xPos, 5);
            Instantiate(bulletPrefab2, spawnPoint, bulletSpawn.rotation);
            xPos += 0.3f;
        }
        Invoke("SetFiring", fireTime);
    }





    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!isFiring)
        {
            if (gap)
            {
                Lasers();
            }
            else
            {
                Fire();
            }
            
        }
    }

    public void SetActive()
    {
        Invoke("SetFiring", 2);
    }

    public void SetInActive()
    {
        isFiring = true;
        CancelInvoke();
    }
}
