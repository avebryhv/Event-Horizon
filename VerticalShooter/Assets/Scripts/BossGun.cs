using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public bool isFiring = true;
    public float maxAmmo = 3;
    public float ammo;
    public int phase = 1;
    void SetFiring()
    {
        isFiring = false;
    }
    void Fire()
    {
        isFiring = true;

        if (ammo != 0)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            Invoke("SetFiring", fireTime);
            ammo--;
        }
        else
        {
            Invoke("SetFiring", 2f);
            ammo = maxAmmo;
        }


    }

    void Phase2() {
        if (phase == 1)
        {
            phase = -1;
            Invoke("PhaseChange2", 2f);
            maxAmmo = 10;
            fireTime = 0.05f;
            
            ammo = 10;
        }
        
    }

    void PhaseChange2() {
        phase = 2;
    }

    void Phase3() {
        if (phase == 2)
        {
            phase = -1;
            Invoke("PhaseChange3", 2f);
            maxAmmo = -1;
            fireTime = 0.2f;
            ammo = 0;
        }
    }
    void PhaseChange3()
    {
        phase = 3;
    }
    void Fire2()
    {
        isFiring = true;

        if (ammo != 0)
        {
            Instantiate(bulletPrefab2, bulletSpawn.position, bulletSpawn.rotation);
            if (GetComponent<AudioSource>() != null)
            {
                GetComponent<AudioSource>().Play();
            }
            Invoke("SetFiring", fireTime);
            ammo--;
        }
        else
        {
            Invoke("SetFiring", 0.15f);
            ammo = maxAmmo;
        }


    }


    // Use this for initialization
    void Start()
    {
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (phase == 1 || phase == 3)
        {
            if (!isFiring)
            {
                Fire();
            }
        }
        else if (phase == 2)
        {         
            
            if (!isFiring)
            {
                Fire2();
            }
        }
       

        

    }
}
