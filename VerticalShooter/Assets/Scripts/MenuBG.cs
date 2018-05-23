using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBG : MonoBehaviour {

    public float speed = 1;
    public Transform self;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;

        if (transform.position.y >= 17)
        {
            Vector2 temp = new Vector2(self.position.x, self.position.y - 24);
            transform.position = temp;
            //Destroy(gameObject);
        }

    }
}
