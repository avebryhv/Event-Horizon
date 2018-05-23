using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VolumeControl : MonoBehaviour {

    public Slider bgmVolume;
    public AudioSource bgmPlayer;
    public AudioSource bossPlayer;

    


	// Use this for initialization
	void Start () {
        bgmVolume.value = bgmPlayer.volume;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChanged()
    {
        bgmPlayer.volume = bgmVolume.value;
        bossPlayer.volume = bgmVolume.value;
    }

    

}
