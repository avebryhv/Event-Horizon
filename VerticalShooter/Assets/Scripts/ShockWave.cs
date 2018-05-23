using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour {

    CircleCollider2D collider;
    float timer = 0;

    // Use this for initialization
    void Start () {
        collider = GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        collider.radius = timer * 5;
        timer += Time.deltaTime;
        

        if (timer >= 0.7)
        {            
            timer = 0;
            Destroy(gameObject);
        }
        //collider.radius;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {            
            Destroy(other);
        }



    }

    public void TakeDamage()
    { }
}
