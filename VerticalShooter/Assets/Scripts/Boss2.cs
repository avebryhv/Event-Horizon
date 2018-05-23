using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss2 : MonoBehaviour {

    public float speed = 2.0f;
    Rigidbody2D rigidbody2D;
    public float stopPoint = 3.0f;
    public int health = 200;
    bool firing = false;
    bool lastDirection = false;
    int phase = 1;
    int timer = 0;
    public GameObject portal;
    public Transform self;
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
        if (health < 200 && health > 125)
        {
            phase = 2;
        }
        if (health <= 125 && health > 50)
        {
            phase = 3;
        }
        if (health <= 50)
        {
            phase = 4;
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
                
                if (firing == false)
                {
                    gameObject.BroadcastMessage("SetFiring");
                    firing = true;
                }
            }
        }
        else if (phase == 2)
        {
           
                timer--;
                if (timer <= 0)
                {
                    timer = health;
                    float x = Random.Range(-6, 2);
                    float y = Random.Range(0, 3);
                    Vector2 temp = new Vector2(x, y);
                    Instantiate(portal, self.position, self.rotation);
                    transform.position = temp;



                }
                rigidbody2D.velocity = new Vector2(0, 0);
                
                gameObject.BroadcastMessage("Phase2");

            
        }
        else if (phase == 3)
        {

            timer--;
            if (timer <= 0)
            {
                timer = health - 20;
                float x = Random.Range(-6, 2);
                float y = Random.Range(0, 3);
                Vector2 temp = new Vector2(x, y);
                TakeDamage(1);
                Instantiate(portal, self.position, self.rotation);
                transform.position = temp;



            }
            rigidbody2D.velocity = new Vector2(0, 0);
                
            gameObject.BroadcastMessage("Phase3");

        }
        else if (phase == 4)
        {
            transform.position = new Vector3(-2, 3);
            gameObject.BroadcastMessage("Phase4");
        }



    }
}
