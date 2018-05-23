using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour {

    

    public void MainMenu()
    {
        SceneManager.LoadScene("MMenu");
    }

    public void Retry() {
        SceneManager.LoadScene("test");
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
