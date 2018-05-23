using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    
    public float speedMax = 5;
    Rigidbody2D rigidbody2D;
    float speed;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        speed = speedMax;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

                
        float x = Input.GetAxis("Horizontal");
        //float y = Input.GetAxis("Vertical");
        //rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.velocity = new Vector2(x, 0) * speed;
        
        rigidbody2D.angularVelocity = 0.0f;
    }
}
