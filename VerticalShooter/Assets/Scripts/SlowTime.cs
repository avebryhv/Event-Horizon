using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour {

    public float MaxCharge = 100;
    public float charge;
    public float rechargeRate = 0.2f;
    public bool Cancel = false;
    public GameObject timeFX;
    public AudioSource bgm;
    public AudioSource bossBGM;

    public GameObject shockwave;
    public int shockwaveCharge;
    public int shockwaveChargeMax;
    public Transform self;

    public AudioSource specialSound;

	// Use this for initialization
	void Start () {
        
        MaxCharge = 100;
        shockwaveChargeMax = 3;
        
        charge = MaxCharge;
        shockwaveCharge = shockwaveChargeMax;
        Time.timeScale = 1f;      
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!Cancel) 
        {
            if (Input.GetButton("Focus"))
            {
                if (charge > 0)
                {
                    Time.timeScale = 0.5f;
                    timeFX.SetActive(true);
                    bgm.pitch = Mathf.Lerp(bgm.pitch, 0.5f, Time.deltaTime * 5f);
                    bossBGM.pitch = Mathf.Lerp(bossBGM.pitch, 0.5f, Time.deltaTime * 5f);
                    charge--;
                }
                else
                {
                    Time.timeScale = 1f;
                    timeFX.SetActive(false);
                    bgm.pitch = Mathf.Lerp(bgm.pitch, 1, Time.deltaTime * 5f);
                    bossBGM.pitch = Mathf.Lerp(bossBGM.pitch, 1f, Time.deltaTime * 5f);

                }
            }
            else
            {
                Time.timeScale = 1f;
                if (charge < MaxCharge)
                {
                    charge += rechargeRate;
                    timeFX.SetActive(false);
                    bgm.pitch = Mathf.Lerp(bgm.pitch, 1, Time.deltaTime * 5f);
                    bossBGM.pitch = Mathf.Lerp(bossBGM.pitch, 1, Time.deltaTime * 5f);

                }
            }
        }

        

        
	}

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (shockwaveCharge > 0)
            {
                Instantiate(shockwave, self.position, self.rotation);
                shockwaveCharge--;
                specialSound.Play();
            }

        }
    }

    public void GainShockwave()
    {
        shockwaveCharge++;
    }
}
