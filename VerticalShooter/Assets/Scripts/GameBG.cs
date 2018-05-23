using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBG : MonoBehaviour {

    public float defSpeed = 1;
    float speed;
    public Transform self;
    public GameUI scoreHolder;

    // Use this for initialization
    void Start()
    {
        speed = defSpeed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = defSpeed + (scoreHolder.score * 0.01f);

        GetComponent<Rigidbody2D>().velocity = -transform.up * speed;

        if (transform.position.y <= 5) //Used to be -7
        {
            Vector2 temp = new Vector2(self.position.x, self.position.y + 12); //Used to be +24
            transform.position = temp;
            //Destroy(gameObject);
        }

    }
}
