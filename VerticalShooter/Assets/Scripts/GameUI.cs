using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameUI : MonoBehaviour {

    public Texture aTexture;
    public GameObject canvas;
    public AudioSource bgmPlayer;
    public AudioSource bossPlayer;
    public Text scoreText;
    public Slider timeSlider;
    public Text UILives;
    public Text UISlow;
    public Text UIScore;
    public Text highScoreText;
    public Text SpecialText;

    public int health;
    public int score;
    int highScore;
    private string gameInfo = "";
    private Rect boxRect = new Rect(650, 200, 300, 50);

    



    void OnEnable()
    {
        PlayerHealth.OnUpdateHealth += HandleonUpdateHealth;
        AddScore.OnSendScore += HandleonSendScore;
    }
    void OnDisable()
    {
        PlayerHealth.OnUpdateHealth -= HandleonUpdateHealth;
        AddScore.OnSendScore -= HandleonSendScore;
    }
    void Start()
    {
        
        Time.timeScale = 1f;

        
        timeSlider.maxValue = 100;
        

        UpdateUI();

    }
    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        //UpdateUI();
    }
    void HandleonSendScore(int theScore)
    {
        score += theScore;
        //UpdateUI();
    }
    void UpdateUI()
    {
        UILives.text = "LIVES: " + health.ToString();
        UISlow.text = "TIME SLOW \nCHARGE: " + Mathf.Floor(GameObject.Find("Player").GetComponent<SlowTime>().charge);
        SpecialText.text = "SPECIAL CHARGE: " + GameObject.Find("Player").GetComponent<SlowTime>().shockwaveCharge;
        UIScore.text = "SCORE: " + score.ToString();
        timeSlider.value = GameObject.Find("Player").GetComponent<SlowTime>().charge;
        //gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString() + "\nCharge: " + GameObject.Find("Player").GetComponent<SlowTime>().charge.ToString();
    }
    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(10, 10, 60, 60), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
        //GUI.Box(boxRect, gameInfo);
    }    private void Update()
    {
        if (health >= 0)
        {
            UpdateUI();
        }
        else
        {
            bgmPlayer.Stop();
            bossPlayer.Stop();
            Time.timeScale = 0f;

            if (PlayerPrefs.HasKey("highScore"))
            {
                int highScore = PlayerPrefs.GetInt("highScore");

                if (score > highScore)
                {
                    PlayerPrefs.SetInt("highScore", score);
                }
            }
            else
            {
                PlayerPrefs.SetInt("highScore", score);
            }

            highScore = PlayerPrefs.GetInt("highScore");
            canvas.SetActive(true);
            scoreText.text = "Score: " + score.ToString();
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        
    }

}
