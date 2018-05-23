using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public bool isPaused = false;
    public GameObject pauseCanvas;
    public AudioSource selectSound;

    //Options Menu
    public GameObject optionsCanvas;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {        

        if (Input.GetButtonDown("Pause"))
        {
            
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


	}

    public void Pause() {
        isPaused = true;
        pauseCanvas.SetActive(true);
        selectSound.Play();
        Time.timeScale = 0f;
    }

    public void Resume() {
        isPaused = false;
        pauseCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenOptions() {
        optionsCanvas.SetActive(true);
        selectSound.Play();
    }

    public void CloseOptions() {
        optionsCanvas.SetActive(false);
        selectSound.Play();
    }

    public void MainMenu() {
        SceneManager.LoadScene("MMenu");
        selectSound.Play();
    }
}
