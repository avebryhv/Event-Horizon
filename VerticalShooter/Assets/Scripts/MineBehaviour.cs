using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour {

    public float speed = 2.0f;
    Rigidbody2D rigidbody2D;
    public float stopPoint = 3.0f;
    public int health = 1;

    public bool rotato = false;
    public float rotateSpeed = 1f;
    public float rotateMod = 1f;
    float horizMod = 1.0f;
    float vertiMod = 1.0f;
    bool firing = false;

    public void TakeDamage()
    {
        
            Destroy(gameObject);
        
    }

    // Use this for initialization
    void Start()
    {
        if (Random.Range(0, 2) == 1)
        {
            rotateMod = -1;
        }


        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotato)
        {
            transform.Rotate(Vector3.forward * rotateSpeed * rotateMod);
            rigidbody2D.velocity = new Vector2(0, -speed);
        }
        else
        {
            rigidbody2D.velocity = -transform.up * speed;
        }
        

            if (transform.position.y > stopPoint)
            {
                //rigidbody2D.velocity = -transform.up * speed;
            }
            else
            {
                if (firing == false)
                {
                    gameObject.BroadcastMessage("SetFiring");
                    firing = true;
                }
                
                rigidbody2D.velocity = new Vector2(0, 0);
            Invoke("TakeDamage", 1f);               

            }
        





    }
}
