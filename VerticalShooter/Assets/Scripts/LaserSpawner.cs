using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour {

    public string type;

    public GameObject bulletPrefab;
    
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public bool isFiring = true;
    public float maxAmmo = 3;
    public float ammo;
    public float cooldown = 2f;

    void FireWide()
    {
        isFiring = true;

        Vector3 leftPos = new Vector3(transform.position.x - 4.7f, transform.position.y);
        Vector3 rightPos = new Vector3(transform.position.x + 4.7f, transform.position.y);

        if (ammo != 0)
        {
            Instantiate(bulletPrefab, leftPos, bulletSpawn.rotation);
            Instantiate(bulletPrefab, rightPos, bulletSpawn.rotation);
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            Invoke("SetFiring", fireTime);
            ammo--;
        }
        else
        {
            Invoke("SetFiring", cooldown);
            ammo = maxAmmo;
        }


    }

    void SetFiring()
    {
        isFiring = false;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (type == "wide")
        {
            if (!isFiring)
            {
                FireWide();
            }
            
        }
	}
}
