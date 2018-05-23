using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5Portal : MonoBehaviour {

    public float activeTime;
    public ParticleSystem ps;
    float timer;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;
        transform.Rotate(Vector3.forward * -1f);

        if (timer > activeTime)
        {
            BroadcastMessage("SetInActive");
            ps.startSize = Mathf.Lerp(ps.startSize, 0, Time.deltaTime);
            //ps.Play();
            
        }

    }
}
