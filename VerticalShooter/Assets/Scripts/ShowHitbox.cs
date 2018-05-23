using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHitbox : MonoBehaviour {

    public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Focus"))
        {
            sprite.enabled = true;
        }
        else
        {
            sprite.enabled = false;
        }
	}
}
