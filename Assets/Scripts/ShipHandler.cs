using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using PubNubAPI;

public class ShipHandler : MonoBehaviour
{
    public GameObject explosion;
    public GameObject boosterRight;
    public GameObject boosterLeft;
    public GameObject mainThruster;
    public GameObject theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    
    public GameObject leftTerminal;
    public GameObject rightTerminal;

    public GameObject theLandingSpot;
    public GameObject completeText;
    public TextMeshPro completedText;
    public GameObject dieText;
    public LandingGearController theLandingGear;
    public Slider healthBar;
    public Slider altitudeBar;
    public Image Fill;
    public Text speedText;
    public Text timerText;
    public Text penaltyText;
    private float timer;
    private float totalPenalty;
    private float totalTime;
    public GameObject Leaderboard;

    public bool shipActive = true;

    public Transform groundCheckPoint;
    public Transform middleOfShip;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public float speed;
    public float minSpeed;
    public float maxSpeed;
    public float hp;
    public float mainThrusterSpeed;

    public bool hasLanded;
    
    private float distanceToGround;
    private float startingDistance;
    private float xPosOfLandingPlatform;
    public bool mainThrusterIsOn;
    public bool rightThrusterIsOn;
    public bool leftThrusterIsOn;
    private float leftThrust = 0f, rightThrust = 0f;
    public float speedTick = 0.02f;

    public AudioClip boosterSound;
    public AudioClip shipExplodingSound;
    AudioSource audioSource;
    public static PubNub pubnub;

    // Use this for initialization
    void Start()
    {
        hasLanded = false;
        mainThrusterIsOn = false;
        leftThrust = 0f;
        rightThrust = 0f;
        hp = 1;
        healthBar.value = hp;
        altitudeBar.value = 1;
        PauseMenu.GameIsPaused = false;
        Leaderboard.SetActive(false);

        xPosOfLandingPlatform = UnityEngine.Random.Range(-250, 250); //Getting the random x place for the landing platform
        Vector3 pos = new Vector3(xPosOfLandingPlatform, theLandingSpot.transform.position.y, theLandingSpot.transform.position.z);
        theLandingSpot.transform.position = pos; //Setting the random value to the actual platform

        startingDistance = Mathf.Abs(groundCheckPoint.position.y - theLandingSpot.transform.position.y);
        audioSource = GetComponent<AudioSource>();
    }

    internal void stopBooster()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (!shipActive)
            {
                if (Input.GetButton("Restart_P1") || Input.GetButton("Restart_P2"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            if (shipActive)
            {
                checkSpeedTick();
                speed += speedTick;
                speedText.text = speed.ToString("0.00"); //i.ToString("000")
                altitudeBar.value = distanceToGround / startingDistance;

                if (speed > 5)
                {
                    speedText.color = Color.red;
                }
                if (speed < 5)
                {
                    speedText.color = Color.green;
                }
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }
                if (speed < minSpeed)
                {
                    speed = minSpeed;
                }

                Health();
                distanceToGround = Mathf.Abs(groundCheckPoint.position.y - theLandingSpot.transform.position.y);

                hasLanded = theLandingSpot.transform.position.y + 4.8 >= groundCheckPoint.position.y;

                if (!hasLanded)
                {
                    transform.Translate(0, -Time.deltaTime * speed, 0);

                    //Time display
                    timer += Time.deltaTime;
                    timerText.color = Color.white;
                    TimeSpan t = TimeSpan.FromSeconds(timer);
                    timerText.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
                }

                if (hasLanded)
                {
                    if ((groundCheckPoint.transform.position.x > xPosOfLandingPlatform - 9) && (groundCheckPoint.transform.position.x < xPosOfLandingPlatform + 9) && (theLandingGear.open) && (speed < 5))
                    {
                        totalTime = timer + totalPenalty;
                        TimeSpan u = TimeSpan.FromSeconds(totalTime);
                        completedText.text = "You Landed \n Your time was " + string.Format("{0:D2}:{1:D2}:{2:D2}", u.Minutes, u.Seconds, u.Milliseconds) + ". \nPress Y to restart";
                        completeText.SetActive(true);
                        speed = 0;
                        shipActive = false;

                        PublishScore();
                        Leaderboard.SetActive(true);

                    }
                    else
                    {
                        hp = 0;
                        dieText.SetActive(true);

                        if (shipActive)
                        {
                            shipActive = false;
                            BreakShip();
                            dieText.SetActive(true);
                            Leaderboard.SetActive(true);
                        }
                    }
                }
            }
        } 
    }

    private void checkSpeedTick()
    {
        GameObject asteroidSpawner = GameObject.Find("CreatorOfAsteroidsv2");
        float testY = transform.position.y;
        if (testY > 800)
        {
            speedTick = 0.01f;
        }
        else if (testY < 800 &&  testY > 600)
        {
            speedTick = 0.02f;
            //asteroidSpawner.GetComponent<AsteroidSpawner>().spawnWave();
        }
        else if (testY < 600 && testY > 400)
        {
            speedTick = 0.03f;
            //asteroidSpawner.GetComponent<AsteroidSpawner>().spawnWave();
        }
        else if (testY < 400 && testY > 250)
        {
            speedTick = 0.04f;
            //asteroidSpawner.GetComponent<AsteroidSpawner>().spawnWave();
        }
        else if (testY < 250 && testY > 150)
        {
            speedTick = 0.05f;
            //asteroidSpawner.GetComponent<AsteroidSpawner>().spawnWave();
        }
        if((int)testY == 800)
        {
            asteroidSpawner.GetComponent<AsteroidSpawner>().SpawnWave();
        }
    }

    public void MainThrusterOn()
    {
        mainThruster.GetComponent<Animator>().SetBool("thrusterOn", true);
        mainThrusterIsOn = true;
    }
    public void MainThrusterOff()
    {
        mainThruster.GetComponent<Animator>().SetBool("thrusterOn", false);
        mainThrusterIsOn = false;
    }
    public void LeftThrusterOn()
    {
        leftThrusterIsOn = true;
        leftThrust = Time.deltaTime * 5f;
        rightThrust = 0;

        boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
        boosterLeft.GetComponent<Animator>().SetBool("boosterOn", true);
        leftTerminal.GetComponent<Animator>().SetBool("TerminalOn", true);
        rightTerminal.GetComponent<Animator>().SetBool("TerminalOn", false);
        
    }
    public void LeftThrusterOff()
    {
        leftThrusterIsOn = false;
        leftThrust = 0;
        rightThrust = 0;

        boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
        boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
        leftTerminal.GetComponent<Animator>().SetBool("TerminalOn", false);
        rightTerminal.GetComponent<Animator>().SetBool("TerminalOn", false);
        
    }
    public void RightThrusterOn()
    {
        rightThrusterIsOn = true;
        rightThrust = -Time.deltaTime * 5f;
        leftThrust = 0;

        boosterRight.GetComponent<Animator>().SetBool("boosterOn", true);
        boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
        leftTerminal.GetComponent<Animator>().SetBool("TerminalOn", false);
        rightTerminal.GetComponent<Animator>().SetBool("TerminalOn", true);
    }
    public void RightThrusterOff()
    {
        rightThrusterIsOn = false;
        leftThrust = 0;
        rightThrust = 0;

        boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
        boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
        leftTerminal.GetComponent<Animator>().SetBool("TerminalOn", false);
        rightTerminal.GetComponent<Animator>().SetBool("TerminalOn", false);
    }
    public void StartBooster()
    {
        if (!hasLanded)
        {
            if (rightThrust + leftThrust < 0)
            {
                if (mainThrusterIsOn)
                {
                    mainThruster.GetComponent<Animator>().SetBool("thrusterActive", true);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterActive", true);
                    speed -= mainThrusterSpeed;
                    theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
                }
                boosterRight.GetComponent<Animator>().SetBool("boosterActive", true);
                theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            if (rightThrust + leftThrust > 0)
            {
                if (mainThrusterIsOn)
                {
                    mainThruster.GetComponent<Animator>().SetBool("thrusterActive", true);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterActive", true);
                    speed -= mainThrusterSpeed;
                    theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
                }
                boosterLeft.GetComponent<Animator>().SetBool("boosterActive", true);
                theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            if (rightThrust + leftThrust == 0)
            {
                if (mainThrusterIsOn)
                {
                    mainThruster.GetComponent<Animator>().SetBool("thrusterActive", true);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterActive", false);
                    boosterRight.GetComponent<Animator>().SetBool("boosterActive", false);
                    speed -= mainThrusterSpeed;
                    theShip.transform.Translate(0, 0, 0);
                }
                theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
            }
        }
    }

    public void StopBooster()
    {
        mainThruster.GetComponent<Animator>().SetBool("thrusterActive", false);
        boosterRight.GetComponent<Animator>().SetBool("boosterActive", false);
        boosterLeft.GetComponent<Animator>().SetBool("boosterActive", false);
        audioSource.Stop();
    }

    public void BreakShip()
    {
        audioSource.PlayOneShot(shipExplodingSound, 1F);
        float force = 20f;
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
        GameObject[] decors = GameObject.FindGameObjectsWithTag("Decor");
        GameObject[] covers = GameObject.FindGameObjectsWithTag("Cover");
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        GameObject[] boosters = GameObject.FindGameObjectsWithTag("Booster");

        foreach (GameObject room in rooms)
        {
            Instantiate(explosion, new Vector3(room.transform.position.x, room.transform.position.y,0), Quaternion.identity);

            room.AddComponent<Rigidbody2D>();
            Rigidbody2D body = room.GetComponent<Rigidbody2D>();
            body.gravityScale = 0.1f;
            Vector2 randomVector = new Vector2(UnityEngine.Random.Range(-force, force), UnityEngine.Random.Range(-force, force));
            if (!hasLanded)
            {
                transform.Rotate(0, 0, UnityEngine.Random.Range(-force, force));
            }            
            body.AddForce(randomVector);
        }
        foreach (GameObject decor in decors)
        {

            Instantiate(explosion, new Vector3(decor.transform.position.x, decor.transform.position.y, 0), Quaternion.identity);
            decor.AddComponent<Rigidbody2D>();
            decor.AddComponent<PolygonCollider2D>();
            Rigidbody2D body = decor.GetComponent<Rigidbody2D>();
            body.gravityScale = 0.1f;
            Vector2 randomVector = new Vector2(UnityEngine.Random.Range(-force, force), UnityEngine.Random.Range(-force, force));
            if (!hasLanded)
            {
                transform.Rotate(0, 0, UnityEngine.Random.Range(-force, force));
            }
            body.AddForce(randomVector);
        }
        foreach (GameObject cover in covers)
        {
            Instantiate(explosion, new Vector3(cover.transform.position.x, cover.transform.position.y, 0), Quaternion.identity);
            cover.AddComponent<Rigidbody2D>();
            cover.AddComponent<PolygonCollider2D>();
            Rigidbody2D body = cover.GetComponent<Rigidbody2D>();
            body.gravityScale = 0.1f;
            Vector2 randomVector = new Vector2(UnityEngine.Random.Range(-force, force), UnityEngine.Random.Range(-force, force));
            if (!hasLanded)
            {
                transform.Rotate(0, 0, UnityEngine.Random.Range(-force, force));
            }
            body.AddForce(randomVector);
        }
        foreach (GameObject door in doors)
        {
            Instantiate(explosion, new Vector3(door.transform.position.x, door.transform.position.y, 0), Quaternion.identity);
            door.AddComponent<Rigidbody2D>();
            Rigidbody2D body = door.GetComponent<Rigidbody2D>();
            body.gravityScale = 0.1f;
            Vector2 randomVector = new Vector2(UnityEngine.Random.Range(-force, force), UnityEngine.Random.Range(-force, force));
            if (!hasLanded)
            {
                transform.Rotate(0, 0, UnityEngine.Random.Range(-force, force));
            }
            body.AddForce(randomVector);
        }

        foreach (GameObject booster in boosters)
        {
            Instantiate(explosion, new Vector3(booster.transform.position.x, booster.transform.position.y, 0), Quaternion.identity);
            booster.AddComponent<Rigidbody2D>();
            Rigidbody2D body = booster.GetComponent<Rigidbody2D>();
            body.gravityScale = 0.1f;
            Vector2 randomVector = new Vector2(UnityEngine.Random.Range(-force, force), UnityEngine.Random.Range(-force, force));
            if (!hasLanded)
            {
                transform.Rotate(0, 0, UnityEngine.Random.Range(-force, force));
            }
            body.AddForce(randomVector);
        }

        foreach (LandingGearController gear in GameObject.FindObjectsOfType(typeof(LandingGearController)))
        {
            Instantiate(explosion, new Vector3(gear.transform.position.x, gear.transform.position.y, 0), Quaternion.identity);
            if (gear.isOpen())
            {
                gear.GetComponent<BoxCollider2D>().enabled = false;
                gear.gameObject.AddComponent<PolygonCollider2D>();
                gear.gameObject.AddComponent<Rigidbody2D>();
            }
            else
            {
                gear.GetComponent<BoxCollider2D>().enabled = true;
                gear.gameObject.AddComponent<Rigidbody2D>();
            }
        }

        thePlayer1.KillPlayer();
        thePlayer2.KillPlayer();
    }
    public void Health()
    {
        healthBar.value = hp;
        if (hp <= 0.30f)
        {
            Fill.color = Color.red;
        }
        if (hp < 0.03f)
        {
            if (shipActive)
            {
                dieText.SetActive(true);
                shipActive = false;
                BreakShip();
                Leaderboard.SetActive(true);
                //hasLanded = true;
            }

        }
    }
    public void ShipIsHit()
    {
        
        hp -= 0.10f;
        //timer += 10;
        totalPenalty += 10;

        penaltyText.color = Color.red;
        penaltyText.text = "+" + totalPenalty;
        
        //penaltyText.text = "";
    }
    public void PublishScore()
    {

        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-7536c573-b8fe-4101-bdb9-fea28d3cd6a9";
        pnConfiguration.SubscribeKey = "sub-c-8c16aaf2-fef4-11e8-9231-4abfa1972993";

        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
        pnConfiguration.UUID = UnityEngine.Random.Range(0f, 999999f).ToString();

        pubnub = new PubNub(pnConfiguration);

        totalTime = timer + totalPenalty;
        TimeSpan u = TimeSpan.FromSeconds(totalTime);
        var usernametext = Name.playerName;// this would be set somewhere else in the code
        var scoretext = string.Format("{0:D2}:{1:D2}:{2:D2}", u.Minutes, u.Seconds, u.Milliseconds);
        MyClass2 myObject = new MyClass2();
        myObject.username = Name.playerName;
        myObject.score = string.Format("{0:D2}:{1:D2}:{2:D2}", u.Minutes, u.Seconds, u.Milliseconds);
        string json = JsonUtility.ToJson(myObject);
        pubnub.Publish()
            .Channel("my_channel")
            .Message(json)
            .Async((result, status) => {
                if (!status.Error)
                {
                    
                }
                else
                {
                    Debug.Log(status.Error);
                    Debug.Log(status.ErrorData.Info);
                }
            });
        //Output this to console when the Button is clicked

    }

}
