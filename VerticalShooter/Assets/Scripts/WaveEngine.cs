using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEngine : MonoBehaviour {

    public float defaultY;
    public float xMin;
    public float xMax;
    public Transform enemySpawn;
    public GameObject[] enemyList; //0 - Turret Enemy
                                   //1 - Spread shot
                                   //2 - Moves horizontally
                                   //3 - Fan of bullets
                                   //4 - Meteor
                                   //5 - Wide Fan
                                   //6 - Mini Boss 1
                                   //7 - Laser Path
                                   //8 - Mine Rain
                                   //9 - Mine Spawner
                                   //10 - Single Mine
                                   //11 - Boss 1
                                   //12 - Boss 2
                                   //13 - Miniboss 2
                                   //14 - Boss 3
                                   //15 - LR Spawner
                                   //16 - Boss 5
                                   //17 - Warning Message

    public float waveTime = 10; //Time between waves
    public bool difficulty; //False = Normal, True = Hard
    int waveCount = 0;
    int timer = 0;
    float stageMid;
    public int startingWave = 0;
    bool isSpawning = false;

    
    public AudioSource bgmPlayer;
    public AudioSource bossPlayer;


	// Use this for initialization
	void Start () {
        stageMid = (xMax + xMin) / 2;
        waveCount = startingWave;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //timer++;
        //if (timer == waveTime * 36)
        //{
        //    WaveSelect(waveCount);
        //    waveCount++;
        //    timer = 0;
        //}
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (!isSpawning)
            {
                isSpawning = true;
                if (PlayerPrefs.GetString("LastDifficulty") == "Hard")
                {
                    Invoke("BossWave", 2.0f);
                }
                else
                {
                    Invoke("NextWave", 2.0f);
                }
                
            }
            
        }
        
	}

    void BossBGM()
    {
        bgmPlayer.Pause();
        bossPlayer.pitch = 1;
        bossPlayer.Play();
    }

    void defBGM()
    {
        bgmPlayer.Play();
        bossPlayer.Stop();
    }

    void NextWave() {
        isSpawning = false;
        WaveSelect(waveCount);
        waveCount++;
    }

    void BossWave()
    {
        isSpawning = false;
        BossSelect(waveCount);
        waveCount++;
    }
    //Effective screen bounds for spawning enemies are x = -3 to 3. 
    //Spawn at y = 5/6 for smooth entry



    void SpawnEnemy(int num, float x) {
        Vector2 temp = new Vector2(x, defaultY);
        Instantiate(enemyList[num], temp, enemySpawn.rotation);
    }

    void SpawnEnemy(int num, float x, float y) {
        Vector2 temp = new Vector2(x, y);
        Instantiate(enemyList[num], temp, enemySpawn.rotation);
    }

    void BossSelect(int waveNum)
    {
        switch (waveNum)
        {
            case 0:
                BossBGM();
                Instantiate(enemyList[17], new Vector3(stageMid, 1), enemySpawn.rotation);
                SpawnEnemy(11, stageMid);
                break;

            case 1:
                Instantiate(enemyList[17], new Vector3(stageMid, 1), enemySpawn.rotation);
                SpawnEnemy(14, stageMid);
                break;

            case 2:
                Instantiate(enemyList[17], new Vector3(stageMid, 1), enemySpawn.rotation);
                SpawnEnemy(12, stageMid);
                break;

            case 3:
                Instantiate(enemyList[17], new Vector3(stageMid, 1), enemySpawn.rotation);
                SpawnEnemy(16, stageMid);
                break;

            default:
                BossSelect(Random.Range(0, 4));
                break;
        }
    }

    void WaveSelect(int waveNum) {
        switch (waveNum)
        {
            case 0:
                SpawnEnemy(2, stageMid);
                break;

            case 1:
                SpawnEnemy(2, stageMid);                
                break;

            case 2:
                SpawnEnemy(2, stageMid-2);
                break;

            case 3:
                SpawnEnemy(0, stageMid-1);                
                break;

            case 4:
                SpawnEnemy(0, stageMid+2);                
                break;

            case 5:
                SpawnEnemy(2, stageMid-3);
                SpawnEnemy(2, stageMid - 2);
                break;

            case 6:
                SpawnEnemy(2, stageMid+3);
                SpawnEnemy(2, stageMid-3);
                break;

            case 7:
                SpawnEnemy(4, 2);
                Instantiate(enemyList[4], new Vector2(stageMid-1.5f, 9f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid, 13f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid, 15f), enemySpawn.rotation);
                waveTime = 10f;
                break;

            case 8:
                SpawnEnemy(3, stageMid+3);
                break;

            case 9:
                SpawnEnemy(0, stageMid-3);                
                SpawnEnemy(0, stageMid+3);
                break;

            case 10:
                Instantiate(enemyList[4], new Vector2(stageMid-3f, 9f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid+3f, 9f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid-1.5f, 13f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid+1.5f, 13f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid, 17f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid-1.5f, 19f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid+1.5f, 19f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid-3f, 23f), enemySpawn.rotation);
                Instantiate(enemyList[4], new Vector2(stageMid+3f, 23f), enemySpawn.rotation);
                break;

            case 11:
                SpawnEnemy(5, stageMid - 1);
                break;

            case 12:
                SpawnEnemy(0, stageMid);
                SpawnEnemy(0, stageMid - 2);
                SpawnEnemy(0, stageMid + 2);
                waveTime = 15f;
                break;

            case 13:
                SpawnEnemy(1, stageMid - 1);
                Instantiate(enemyList[0], new Vector2(stageMid + 3f, 9f), enemySpawn.rotation);
                break;

            case 14:
                SpawnEnemy(5, stageMid - 3);
                Instantiate(enemyList[0], new Vector2(stageMid + 1f, 9f), enemySpawn.rotation);
                Instantiate(enemyList[0], new Vector2(stageMid - 0f, 13f), enemySpawn.rotation);
                waveTime = 30f;
                break;

            case 15:
                SpawnEnemy(6, stageMid);
                break;

            case 16:
                SpawnEnemy(2, stageMid - 3);
                SpawnEnemy(2, stageMid - 2);
                SpawnEnemy(2, stageMid - 1);
                SpawnEnemy(2, stageMid);                
                break;

            case 17:
                SpawnEnemy(2, stageMid + 3);
                SpawnEnemy(2, stageMid + 2);
                SpawnEnemy(2, stageMid + 1);
                SpawnEnemy(2, stageMid);
                break;

            case 18:
                SpawnEnemy(2, stageMid - 3);
                SpawnEnemy(2, stageMid - 2);
                SpawnEnemy(2, stageMid - 1);
                SpawnEnemy(2, stageMid);
                SpawnEnemy(2, stageMid + 3);
                SpawnEnemy(2, stageMid + 2);
                SpawnEnemy(2, stageMid + 1);
                break;

            case 19:
                SpawnEnemy(7, stageMid);
                break;

            case 20:
                SpawnEnemy(10, stageMid + Random.Range(-1,1));
                break;

            case 21:
                SpawnEnemy(10, stageMid + 2);
                SpawnEnemy(10, stageMid - 2);
                break;

            case 22:
                SpawnEnemy(10, stageMid + 3);
                //SpawnEnemy(10, stageMid + 2);
                SpawnEnemy(10, stageMid + 1);
                //SpawnEnemy(10, stageMid);
                SpawnEnemy(10, stageMid -1);
                //SpawnEnemy(10, stageMid - 2);
                SpawnEnemy(10, stageMid - 3);
                break;

            case 23:
                SpawnEnemy(9, stageMid);
                break;

            case 24:
                WaveSelect(10);
                break;

            case 25:
                Instantiate(enemyList[17], new Vector3(stageMid, 1), enemySpawn.rotation);
                SpawnEnemy(11, stageMid);
                BossBGM();
                break;

            case 26:
                SpawnEnemy(9, stageMid);
                defBGM();
                break;

            case 27:
                SpawnEnemy(7, stageMid - 3);
                break;

            case 28:
                Instantiate(enemyList[2], new Vector2(stageMid +2f, 5f), enemySpawn.rotation);
                Instantiate(enemyList[2], new Vector2(stageMid +1f, 6f), enemySpawn.rotation);
                Instantiate(enemyList[2], new Vector2(stageMid, 7f), enemySpawn.rotation);
                Instantiate(enemyList[2], new Vector2(stageMid - 1f, 8f), enemySpawn.rotation);
                Instantiate(enemyList[2], new Vector2(stageMid - 2f, 9f), enemySpawn.rotation);
                Instantiate(enemyList[2], new Vector2(stageMid -3f, 10f), enemySpawn.rotation);
                break;

            case 29:
                SpawnEnemy(0, stageMid - 2, 5f);
                SpawnEnemy(0, stageMid - 1, 9f);
                SpawnEnemy(0, stageMid + 1, 11f);
                SpawnEnemy(0, stageMid + 2, 15f);
                break;

            case 30:
                SpawnEnemy(15, stageMid);
                break;

            case 31:
                SpawnEnemy(0, stageMid - 3);
                SpawnEnemy(0, stageMid + 3);
                SpawnEnemy(0, stageMid - 1);
                SpawnEnemy(0, stageMid + 1);
                break;

            case 32:
                SpawnEnemy(7, stageMid - 3);
                break;

            case 33:
                for (int i = -3; i < 4; i++)
                {
                    SpawnEnemy(0, stageMid + i, 9 + i);
                }
                break;

            case 34:
                SpawnEnemy(13, stageMid);
                break;

            case 35:
                Instantiate(enemyList[17], new Vector3(stageMid, 1), enemySpawn.rotation);
                SpawnEnemy(14, stageMid);
                BossBGM();
                break;

            case 36:
                defBGM();
                break;

            case 45:
                Instantiate(enemyList[17], new Vector3(stageMid, 1), enemySpawn.rotation);
                SpawnEnemy(12, stageMid);
                BossBGM();
                break;

            case 46:
                defBGM();
                break;

            case 60:
                Instantiate(enemyList[17], new Vector3(stageMid, 1), enemySpawn.rotation);
                SpawnEnemy(16, stageMid);
                BossBGM();
                break;

            case 61:
                defBGM();
                break;

            default:
                //defBGM();
                int randWave = Random.Range(5, 35);
                WaveSelect(randWave);
                break;
        }
    }


}
