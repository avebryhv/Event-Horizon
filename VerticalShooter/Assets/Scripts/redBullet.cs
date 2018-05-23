using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redBullet : MonoBehaviour {

    public float speed = 10f;
    public float destroyTime = 1.5f;
    public string damageTag = "";
    public bool speedUp = false;


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
        GetComponent<Rigidbody2D>().velocity = -transform.up * speed;

        if (speedUp)
        {
            speed = speed * 1.1f;
        }


        if (transform.position.y > 6)
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
