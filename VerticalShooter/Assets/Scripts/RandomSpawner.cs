using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public bool isFiring = true;
    public bool facePlayer = false;
    public float maxAmmo = 3;
    public float cooldown = 2f;
    float ammo;

    void SetFiring()
    {
        isFiring = false;
    }
    void Fire()
    {
        isFiring = true;

        if (ammo != 0)
        {
            float x = Random.Range(-6, 2.5f);
            Vector3 spawnPoint = new Vector3(x, 5, 0);
            Instantiate(bulletPrefab, spawnPoint, bulletSpawn.rotation);
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

    void Start()
    {
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isFiring)
        {
            Fire();
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
