using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int Lives = 3;
    public bool Immune = false;
    public bool Shield = false;
    SpriteRenderer sprite;

    public GameObject Player;
    public Sprite defPlayer;
    public Sprite flashPlayer;

    public AudioSource shieldSound;
    public AudioSource hurtSound;

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    public void TakeDamage()
    {
        if (Immune == true)
        {

        }
        else
        {
            if (Shield == false)
            {
                Immune = true;
                StartCoroutine(RemoveImmune(3));
                Player.GetComponent<SpriteRenderer>().sprite = flashPlayer;
                Lives--;
                hurtSound.Play();
                SendHealthData();
            }
            else
            {
                Shield = false;
                sprite.enabled = false;
                Player.GetComponent<SpriteRenderer>().sprite = flashPlayer;
                Immune = true;
                StartCoroutine(RemoveImmune(5));
            }
        }
    }    

    IEnumerator RemoveImmune(float time)
    {
        yield return new WaitForSeconds(time);
        Player.GetComponent<SpriteRenderer>().sprite = defPlayer;
        Immune = false;
        // Code to execute after the delay
    }   

    public void GainShield() {
        Shield = true;
        sprite.enabled = true;
        shieldSound.Play();
    }

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();        

        if (PlayerPrefs.GetString("LastDifficulty") == "Hard")
        {
            //Lives = 1;
        }
        else
        {
            Lives = 3;
        }

        SendHealthData();
    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(Lives);
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
