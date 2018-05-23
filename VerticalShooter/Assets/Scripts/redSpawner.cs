using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redSpawner : MonoBehaviour {

    Transform target;
    public float smoothing = 5.0f;
    public float adjustmentAngle = 0.0f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = true;
    

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
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
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
            Fire();
        }
        
    }
}
