using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBehaviour : MonoBehaviour {

    public float speed = 2.0f;
    Rigidbody2D rigidbody2D;
    Transform target;

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
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > -2.0)
        {
            rigidbody2D.velocity = -transform.up * speed;
        }
        else
        {
            if (target != null)
            {
                if (GetComponent<Rigidbody2D>() != null)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
                }
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
            }
        }

    }
}
