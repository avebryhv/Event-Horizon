using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Gun : MonoBehaviour {

    public int gunNumber;

    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;

    public Transform bulletSpawn;

    public int health = 200;

    public float fireTime = 0.5f;
    public bool isFiring = true;
    public float maxAmmo = 3;
    public float ammo;
    public int phase = 1;
    public float cooldown = 2f;

    public int timer = 0;

    Transform target;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 90f;

    // Use this for initialization
    void Start()
    {
        ammo = maxAmmo;
        target = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (phase == 1)
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
                Fire(bulletPrefab);

            }
        }
        else if (phase == 2)
        {
            timer++;
            if (gunNumber == 1)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                if (timer == 1)
                {
                    Lasers();
                }
            }
            else if (gunNumber == 2)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                if (timer == 180)
                {
                    Rain(bulletPrefab3, 20);
                }
            }
            else if (gunNumber == 3)
            {
                if (target != null)
                {
                    Vector3 difference = target.position - transform.position;
                    difference.Normalize();
                    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
                    transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
                }
                if (timer > 360 && timer < 430 && !isFiring)
                {
                    Fire(bulletPrefab);
                }
            }
            else if (gunNumber == 4)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                if (timer == 450)
                {
                    Rain(bulletPrefab2, 12);
                }
            }
            if (timer == 700)
            {
                timer = 0;
            }

        }
        else if (phase == 3)
        {
            timer++;
            if (gunNumber == 2)
            {
                if (timer == 1 || timer == 150 || timer == 300 || timer == 450)
                {
                    Lasers();
                }
            }
            else if (gunNumber == 3)
            {
                if (timer == 600 || timer == 800)
                {
                    Rain(bulletPrefab2, Random.Range(3, 7));
                }

            }
            else
            {
                if (target != null)
                {
                    Vector3 difference = target.position - transform.position;
                    difference.Normalize();
                    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    Quaternion newRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotZ + adjustmentAngle));
                    transform.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * smoothing);
                }
                if (!isFiring && timer > 600)
                {
                    Fire(bulletPrefab);
                }
            }

            if (timer == 1000)
            {
                timer = 0;
            }
        }





        if (gunNumber == 1)
        {

        }
        else if (gunNumber == 2)
        {

        }
        else if (gunNumber == 3)
        {

        }
        else if (gunNumber == 4)
        {

        }
	}

    void SetFiring()
    {
        isFiring = false;

    }
    void Fire(GameObject bullet)
    {
        isFiring = true;

        if (ammo != 0)
        {
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
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

    void Rain(GameObject bullet, int bulletCount)
    {
        isFiring = true;
        float tempPos = -8f;
        float interval = 14f/bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            Vector2 spawnPoint = new Vector2(tempPos, 5);
            Instantiate(bullet, spawnPoint, bulletSpawn.rotation);
            tempPos += interval;
        }

        Invoke("SetFiring", fireTime);
    }

    void Lasers()
    {
        int rand = Random.Range(3, 24);
        isFiring = true;
        float xPos = -7f;
        for (int i = 0; i < rand; i++)
        {
            Vector2 spawnPoint = new Vector2(xPos, 5);
            Instantiate(bulletPrefab2, spawnPoint, bulletSpawn.rotation);
            xPos += 0.3f;
        }
        xPos += 0.6f;
        for (int i = rand; i < 30; i++)
        {
            Vector2 spawnPoint = new Vector2(xPos, 5);
            Instantiate(bulletPrefab2, spawnPoint, bulletSpawn.rotation);
            xPos += 0.3f;
        }
        Invoke("SetFiring", 4);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Phase2() {
        isFiring = true;
        Invoke("SetFiring", 2);
        phase = 2;
    }

    void Phase3() {
        isFiring = true;
        Invoke("SetFiring", 2);
        phase = 3;
    }
}
