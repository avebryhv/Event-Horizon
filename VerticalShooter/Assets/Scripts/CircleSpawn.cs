using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawn : MonoBehaviour {

    public GameObject bulletPrefab;    
    public float fireTime = 5f;
    public bool isFiring = false;
    public Transform bulletSpawn;    
    float timer = 0;

    void SetFiring()
    {
        isFiring = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!isFiring)
        {
            Fire();
        }
        
    }

    void Fire()
    {
        transform.rotation = new Quaternion(0,0,180,0);

        isFiring = true;

        int rand = Random.Range(80, 95);

        for (int i = 0; i < rand; i++)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            transform.Rotate(Vector3.forward * 2f);
        }

        transform.Rotate(Vector3.forward * 15f);

        for (int i = rand; i < 180; i++)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            transform.Rotate(Vector3.forward * 2f);
        }




        Invoke("SetFiring", fireTime);
            
        
        


    }
}
