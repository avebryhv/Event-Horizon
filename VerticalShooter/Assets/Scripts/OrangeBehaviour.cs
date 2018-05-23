using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBehaviour : MonoBehaviour {

    public float speed = 2f;
    Rigidbody2D rigidbody2D;
    public string damageTag = "";
    public int health = 10;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        
        //speed = Random.Range(6f, 12f);        
        rigidbody2D.velocity = -transform.up * speed;

        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageTag))
        {
            other.SendMessage("TakeDamage");
            Destroy(gameObject);
        }



    }
}
