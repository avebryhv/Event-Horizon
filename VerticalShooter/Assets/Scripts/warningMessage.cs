using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warningMessage : MonoBehaviour {

    SpriteRenderer sprite;
    float timer;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        timer += Time.deltaTime;

        if (timer > 0.7f)
        {
            //sprite.color = Color.Lerp(sprite.color, new Color(255, 255, 255, 1), Time.deltaTime);
            sprite.color = new Color(255, 255, 255, 0.5f);
        }
        else
        {
            //sprite.color = Color.Lerp(sprite.color, new Color(255, 255, 255, 1), Time.deltaTime / 2);
            sprite.color = new Color(255, 255, 255, 1f);
        }

        if (timer > 1.1f)
        {
            timer = 0;
        }
        
        //sprite.color = new Color(255, 255, 255, 0.5f);
	}
}
