using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPortal : MonoBehaviour {

    public float health;
    public ParticleSystem effect;

    public UnityEvent onTakeDamage;

    // Use this for initialization
    void Start () {
		
	}

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

    // Update is called once per frame
    void Update () {
		
	}
}
