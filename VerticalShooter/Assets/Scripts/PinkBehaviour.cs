using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinkBehaviour : MonoBehaviour {

    public float speed = 2.0f;
    Rigidbody2D rigidbody2D;
    public float stopPoint = 3.0f;
    public int health = 10;
    public bool horizontalMove = false;
    public bool continueMove = true;
    float horizMod = 1.0f;
    float vertiMod = 1.0f;
    bool firing = false;

    public UnityEvent onTakeDamage;

    public void TakeDamage(int damage)
    {
        health -= damage;
        onTakeDamage.Invoke();
        if (health <= 0)
        {
            GetComponent<AddScore>().DoSendScore();
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (horizontalMove == true)
        {
            //Reverses x direction to bounce down the screen
            if (transform.position.x > 2)
            {
                horizMod = -1.0f;
            }
            else if (transform.position.x < -6)
            {
                horizMod = 1.0f;
            }

            //Changes behaviour at a certain y point
            if (transform.position.y < stopPoint)
            {
                if (continueMove == false)
                {
                    vertiMod = 0;

                }
                else
                {
                    vertiMod = 0.2f;
                }
                if (firing == false) //Starts shooting
                {
                    gameObject.BroadcastMessage("SetFiring");
                    firing = true;
                }
            }

            rigidbody2D.velocity = new Vector2(horizMod, -vertiMod) * speed;
        }
        else
        {
            
            if (transform.position.y > stopPoint)
            {
                rigidbody2D.velocity = -transform.up * speed;
            }
            else
            {
                if (firing == false)
                {
                    gameObject.BroadcastMessage("SetFiring");
                    firing = true;
                }
                if (continueMove)
                {
                    
                    rigidbody2D.velocity = -transform.up * 0.2f;
                }
                else
                {
                    rigidbody2D.velocity = new Vector2(0,0);
                }

            }
        }
        //Destroys if the enemy goes past the player
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }



        

	}
}
