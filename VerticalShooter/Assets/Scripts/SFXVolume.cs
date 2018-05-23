using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SFXVolume : MonoBehaviour {

    public List<AudioSource> SFXPlayers;
    public Slider VolumeSlider;

    // Use this for initialization
    void Start () {

        VolumeSlider.value = 0.7f;

        foreach (var source in SFXPlayers)
        {
            source.volume = VolumeSlider.value;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChanged() {
        foreach (var source in SFXPlayers)
        {
            source.volume = VolumeSlider.value;
        }
    }

}
