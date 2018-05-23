using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public AudioSource buttonSelect;
    public GameObject controlScreen;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("test");
        buttonSelect.Play();
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Game Over");
        
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        buttonSelect.Play();
    }    public void QuitGame() {
        Application.Quit();
    }    public void StartNormal()
    {
        DifficultySelect("Normal");
        SceneManager.LoadScene("test");
        buttonSelect.Play();
    }    public void StartHard()
    {
        DifficultySelect("Hard");
        SceneManager.LoadScene("test");
        buttonSelect.Play();
    }    public void ShowControls()
    {
        controlScreen.SetActive(true);
        buttonSelect.Play();
    }    public void HideControls()
    {
        controlScreen.SetActive(false);
        buttonSelect.Play();
    }    void DifficultySelect(string diff)
    {
        PlayerPrefs.SetString("LastDifficulty", diff);
    }


}
