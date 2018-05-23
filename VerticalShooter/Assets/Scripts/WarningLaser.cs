using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLaser : MonoBehaviour {

    public bool aiming = true;
    public float aimTime = 1.5f;
    public float fireTime = 1.5f;
    public string damageTag = "";
    public GameObject laser;
    public Transform spawnpoint;

    // Use this for initialization
    void Start () {
        if (aiming)
        {
            Invoke("Fire", aimTime);
        }
        else
        {
            Invoke("Die", fireTime);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    void Fire()
    {
        Instantiate(laser, spawnpoint.position, spawnpoint.rotation);
        Destroy(gameObject);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        CancelInvoke("Die");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (aiming == false)
        {
            if (other.CompareTag(damageTag))
            {
                other.SendMessage("TakeDamage");
                Destroy(gameObject);
            }
        }    



    }
}
