using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstSpawn : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    public bool isFiring = true;
    public bool facePlayer = false;
    public float maxAmmo = 3;
    public float cooldown = 2f;
    Transform target;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;
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


    // Use this for initialization
    void Start()
    {
        ammo = maxAmmo;
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
            if (!isFiring)
            {
                Fire();
            }

        if (facePlayer)
        {
            if (target != null)
            {
                Vector3 difference = target.position - transform.position;
                difference.Normalize();
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
                transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
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
