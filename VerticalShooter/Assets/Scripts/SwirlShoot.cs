using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwirlShoot : MonoBehaviour {

    public GameObject bulletPrefab;
    public int ammo = 10;
    public float fireTime = 0.3f;
    public bool isFiring = false;
    public Transform bulletSpawn;
    public int maxAmmo;
    public float cooldown = 2f;
    public int rotateMod;
    public float timer = 0;
    public float switchTime = 90;
    // Use this for initialization
    void Start () {
        
        ammo = maxAmmo;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;
        if (timer > switchTime)
        {
            rotateMod *= -1;
            timer = 0;
        }
        gameObject.transform.Rotate(Vector3.forward * -1f * rotateMod);
        //Debug.Log()
        if (!isFiring)
        {
            Fire();
        }

        

    }

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
}
