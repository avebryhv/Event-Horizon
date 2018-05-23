using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss1 : MonoBehaviour {

    public float speed = 2.0f;
    Rigidbody2D rigidbody2D;
    public float stopPoint = 3.0f;
    public int health = 500;
    bool firing = false;
    bool lastDirection = false;
    int phase = 1;
    public UnityEvent onTakeDamage;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        onTakeDamage.Invoke();
        if (health <= 0)
        {
            Destroy(gameObject);
            GetComponent<AddScore>().DoSendScore();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Rotate(Vector3.forward * -1f);
        if (health < 350 && health > 200)
        {
            phase = 2;
        }
        if (health < 201)
        {
            phase = 3;
        }

        if (phase == 1)
        {
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
        else if (phase == 2)
        {
            if (transform.position.y < 3)
            {
                transform.position += new Vector3(0 , 0.1f);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(0, 0);
                transform.Rotate(Vector3.forward * -1f);
                gameObject.BroadcastMessage("Phase2");
                
            }
        }
        else if (phase == 3)
        {
            if (transform.position.y > 1)
            {
                transform.position += new Vector3(0, -0.1f);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(0, 0);
                transform.Rotate(Vector3.forward * 1f);
                gameObject.BroadcastMessage("Phase3");
            }
        }
        


    }
}
