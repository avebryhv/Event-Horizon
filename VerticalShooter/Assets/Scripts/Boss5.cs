using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss5 : MonoBehaviour {

    Transform target;
    public float smoothing = 5.0f;    

    public int phase = 0;
    Rigidbody2D rigidbody2D;
    public float stopPoint = 3.0f;
    public int health = 1500;
    public float speed = 1;
    public float timer = 0;

    public UnityEvent onTakeDamage;

    public BurstSpawn leftBurst;
    public BurstSpawn rightBurst;
    public BurstSpawn roMineBurst;

    public GameObject portal;

    public GameObject leftSide;
    public GameObject rightSide;

    public AudioSource bossAudio;

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        timer = 10;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        onTakeDamage.Invoke();
        CheckHealth();
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("ShipFull").GetComponent<SlowTime>().Cancel = false;
            Time.timeScale = 1f;
            Destroy(gameObject);
            GetComponent<AddScore>().DoSendScore();
        }
    }

    void CheckHealth()
    {
        if (health < 1300 && phase == 1)
        {
            leftBurst.SetInActive();
            rightBurst.SetInActive();
            timer = 12;
            phase = 2;
        }
        if (health < 1000 && phase == 2)
        {
            roMineBurst.SetActive();
            timer = 0;
            phase = 3;
        }
        if (health < 850 && phase == 3)
        {
            roMineBurst.SetInActive();
            timer = 12;
            phase = 4;
        }
        if (health < 500 && phase == 4)
        {
            GameObject.FindGameObjectWithTag("ShipFull").GetComponent<SlowTime>().Cancel = true;
            Time.timeScale = 1f;
            timer = 10;
            phase = 5;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.y > stopPoint)
        {
            rigidbody2D.velocity = -transform.up * speed;
        }
        else
        {
            rigidbody2D.velocity = new Vector2();
            Vector3 newPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * 0.01f));

            if (phase == 0)
            {
                leftBurst.SetActive();
                rightBurst.SetActive();
                phase++;
            }
            else if (phase == 2)
            {
                timer += Time.deltaTime;
                if (timer > 14)
                {
                    float xPos = Random.Range(-5, 1);
                    float yPos = Random.Range(-1, 2);

                    Instantiate(portal, new Vector3(xPos, yPos), new Quaternion());

                    timer = 0;
                }

            }
            else if (phase == 4)
            {
                timer += Time.deltaTime;

                if (timer > 14)
                {
                    float yPos = Random.Range(-1, 2);

                    Instantiate(portal, new Vector3(1, yPos), new Quaternion());
                    Instantiate(portal, new Vector3(-5, yPos), new Quaternion());
                    timer = 0;
                }


            }
            else if (phase == 5)
            {
                //leftSide.transform.localPosition = new Vector3(-1, 0);
                //Mathf.Lerp(leftSide.transform.position.x, -1, Time.deltaTime);
                //Mathf.Lerp(rightSide.transform.position.x, 1, Time.deltaTime);

                leftSide.transform.localPosition = Vector3.Lerp(leftSide.transform.localPosition, new Vector3(-0.5f, 0), Time.deltaTime);
                rightSide.transform.localPosition = Vector3.Lerp(rightSide.transform.localPosition, new Vector3(0.5f, 0), Time.deltaTime);
                GameObject.FindGameObjectWithTag("ShipFull").GetComponent<SlowTime>().Cancel = true;
                timer += Time.deltaTime;
                
                bossAudio.pitch = Mathf.Lerp(bossAudio.pitch, 0.5f, Time.deltaTime * 5f);
                if (timer > 14)
                {
                    float yPos = Random.Range(-1, 2);

                    Instantiate(portal, new Vector3(1, yPos), new Quaternion());
                    Instantiate(portal, new Vector3(-5, yPos), new Quaternion());
                    Instantiate(portal, new Vector3(-2, yPos + 1), new Quaternion());
                    Instantiate(portal, new Vector3(1, yPos + 2), new Quaternion());
                    Instantiate(portal, new Vector3(-5, yPos + 2), new Quaternion());

                    Time.timeScale = 0.5f;
                    timer = 0;
                }
            }


            

        }

        


    }
}
