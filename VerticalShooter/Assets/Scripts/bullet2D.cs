using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2D : MonoBehaviour {

    public float speed = 5.0f;
    public float destroyTime = 0.7f;
    public int damage = 1;
    public string damageTag = "";
    public bool speedUp = false;
    public Transform self;
    //public GameObject hitEffect;

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
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;

        if (speedUp)
        {
            speed = speed + 0.1f;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageTag))
        {
            other.SendMessage("TakeDamage", damage);
            //Instantiate(hitEffect, self.position, self.rotation);
            Destroy(gameObject);
        }



    }
}
