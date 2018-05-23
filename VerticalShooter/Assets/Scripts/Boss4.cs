using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss4 : MonoBehaviour {

    Transform target;
    public float smoothing = 5.0f;

    public BurstSpawn leftGun;
    public BurstSpawn rightGun;
    public BurstSpawn midGun;
    public RainSpawner rainSpawn;
    public BurstSpawn rotateGun;

    public int phase = 1;
    Rigidbody2D rigidbody2D;
    public float stopPoint = 3.0f;
    public int health = 500;
    public float speed = 1;

    public UnityEvent onTakeDamage;

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        rainSpawn.SetInActive();
        rotateGun.SetInActive();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        
            if (transform.position.y > stopPoint)
            {
                rigidbody2D.velocity = -transform.up * speed;
            }
            else
            {
                rigidbody2D.velocity = new Vector2();
                Vector3 newPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.01f));

                leftGun.maxAmmo = 5;
                rightGun.maxAmmo = 5;
                midGun.maxAmmo = -1;
            }
        


        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        onTakeDamage.Invoke();
        CheckHealth();
        if (health <= 0)
        {
            Destroy(gameObject);
            GetComponent<AddScore>().DoSendScore();
        }
    }

    void CheckHealth()
    {
        if (health < 200 && phase == 1)
        {
            rainSpawn.SetActive();
            midGun.SetInActive();
            leftGun.SetInActive();
            rightGun.SetInActive();
            phase = 2;
        }
        if (health < 100 && phase == 2)
        {
            rainSpawn.SetInActive();
            leftGun.SetActive();
            rightGun.SetActive();
            rotateGun.SetActive();
            leftGun.cooldown = 1f;
            rightGun.cooldown = 1f;
            phase = 3;

        }
    }
}
