﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDown : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;


    void SetFiring()
    {
        isFiring = false;
    }
    void Fire()
    {
        isFiring = true;



        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        Invoke("SetFiring", fireTime);
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
           


        if (!isFiring)
        {
            Fire();
        }

    }
}
