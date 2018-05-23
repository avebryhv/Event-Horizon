using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossShot : MonoBehaviour {

    Vector3 startPosition;
    public int mode;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        startPosition = GameObject.Find("Player").transform.position + new Vector3(0, 1);
        transform.position = startPosition;

        if (mode == 2)
        {
            for (int i = 0; i < 12; i++)
            {
                Instantiate(bullet, new Vector3(Mathf.Sin(i * 30), Mathf.Cos(i * 30)), new Quaternion(0, 0, 30 * i, 0));
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
