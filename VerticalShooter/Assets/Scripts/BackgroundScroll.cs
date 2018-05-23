using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public float speed = 2.0f;
    Rigidbody2D rigidbody2D;
    public float decayTime;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rigidbody2D.velocity = -transform.up * speed;
	}

    private void Awake()
    {
        Destroy(gameObject ,decayTime);
    }
}
