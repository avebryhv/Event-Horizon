using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour {

    public delegate void SendScore(int theScore);
    public static event SendScore OnSendScore;
    public int score = 10;
    
    public GameObject shield;
    public bool guaranteeShield = false;
    public GameObject shockwave;
    public Transform self;
    public GameObject implode;
    public GameObject astro;

    public AudioSource deathSound;

    public void DoSendScore()
    {
        deathSound.Play();
        Debug.Log("boom");
        int RNG = Random.Range(0, 100);

        if (OnSendScore != null)
        {
            OnSendScore(score);
        }

        //Chance of spawning an item upon death
        if (guaranteeShield)
        {
            Instantiate(shield, self.position, self.rotation);
        }
        else if (RNG > 95)
        {
            Instantiate(shield, self.position, self.rotation);
        }
        else if (RNG < 5)
        {
            Instantiate(shockwave, self.position, self.rotation);
        }
        else if (RNG == 50)
        {
            Instantiate(astro, self.position, self.rotation);
        }

        if (implode != null)
        {
            Instantiate(implode, self.position, self.rotation);
        }

    }

}
