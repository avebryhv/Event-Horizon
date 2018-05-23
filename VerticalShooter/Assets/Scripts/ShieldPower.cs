﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPower : MonoBehaviour {

    public float speed = 10f;
    public float destroyTime = 1.5f;
    public string playerTag = "";

    // Use this for initialization
    void Start()
    {
        Invoke("Die", destroyTime);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        CancelInvoke("Die");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            other.SendMessage("GainShield");
            Destroy(gameObject);
        }



    }
}
