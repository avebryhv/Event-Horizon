using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagBullet : MonoBehaviour {

    Rigidbody2D rigidbody2D;
    public float speed = 10f;
    public float destroyTime = 1.5f;
    public string damageTag = "";
    int timer = 0;
    int direction = 1;
    public bool randomDir = false;
    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke("Die", destroyTime);
        if (Random.Range(0,2) >= 1 && randomDir == true)
        {
            direction = -1;
        }
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
        timer++;
        if (timer >= 50)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            if (timer >= 70)
            {
                direction *= -1;
                timer = 0;
                
            }
        }
        else
        {
            rigidbody2D.velocity = new Vector2(direction * 1, -speed);
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
