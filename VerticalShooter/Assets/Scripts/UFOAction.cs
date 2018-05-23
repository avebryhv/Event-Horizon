using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOAction : MonoBehaviour {

    public float speed = 2.0f;
    Rigidbody2D rigidbody2D;
    public float stopPoint = 3.0f;
    public int health = 50;
    bool firing = false;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        //transform.Rotate(Vector3.forward * -1f);

        if (transform.position.y > stopPoint)
        {
            rigidbody2D.velocity = -transform.up * speed;
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            transform.Rotate(Vector3.forward * -1f);
            if (firing == false)
            {
                gameObject.BroadcastMessage("SetFiring");
                firing = true;
            }
        }


    }
}
