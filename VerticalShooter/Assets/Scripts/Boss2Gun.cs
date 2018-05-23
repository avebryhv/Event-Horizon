using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Gun : MonoBehaviour {

    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public bool isFiring = true;
    public float maxAmmo = 3;
    public float ammo;
    public int phase = 1;
    public float cooldown = 2f;

    Transform target;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 90f;

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
            Invoke("SetFiring", cooldown);
            ammo = maxAmmo;
        }


    }

    void Phase2()
    {
        if (phase == 1)
        {
            phase = -1;
            Invoke("PhaseChange2", 2f);
            maxAmmo = 10;
            fireTime = 0.05f;

            ammo = 10;
        }

    }

    void PhaseChange2()
    {
        phase = 2;
    }

    void Phase3()
    {
        if (phase == 2)
        {
            phase = -1;
            Invoke("PhaseChange3", 2f);
            maxAmmo = 8;
            fireTime = 0.1f;
            ammo = 0;
        }
    }
    void PhaseChange3()
    {
        phase = 3;
    }

    void Phase4() {
        if (phase == 3)
        {
            phase = -1;
            Invoke("PhaseChange4", 1f);
            maxAmmo = 10;
            fireTime = 0.01f;
            ammo = 0;
            cooldown = 0.3f;
        }
    }

    void PhaseChange4()
    {
        phase = 4;
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
            Invoke("SetFiring", 1f);
            ammo = maxAmmo;
        }
    }


    


    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player").transform;
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (phase == 2)
        {
            if (!isFiring)
            {
                Fire();
            }
        }
        else if (phase == 3)
        {

            if (target != null)
            {
                Vector3 difference = target.position - transform.position;
                difference.Normalize();
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
                transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
            }


            if (!isFiring)
            {
                Fire2();
            }
        }
        else if (phase == 4)
        {
            transform.Rotate(Vector3.forward * 5f);
            if (!isFiring)
            {
                Fire();
            }
        }




    }
}
