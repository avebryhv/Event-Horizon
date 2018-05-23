using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBullet : MonoBehaviour {

    public float speed = 5.0f;
    public float destroyTime = 0.7f;
    public int damage = 1;
    public string damageTag = "";

    private float RotateSpeed = 10f;
    private float Radius = 0.1f;

    private Vector2 _centre;
    private float _angle;
    // Use this for initialization
    void Start()
    {
        Invoke("Die", destroyTime);
        _centre = transform.position;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        CancelInvoke("Die");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;
        Radius += 0.05f;
        RotateSpeed -= 0.05f;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(damageTag))
        {
            other.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }



    }
}

