﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipHandler : MonoBehaviour
{
    public GameObject explosion;
    public GameObject boosterRight;
    public GameObject boosterLeft;
    public GameObject mainThruster;
    public GameObject theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;

    public GameObject theLandingSpot;
    public GameObject completeText;
    public GameObject dieText;
    public LandingGearController theLandingGear;
    public Slider healthBar;
    public Image Fill;

    public bool shipActive = true;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public float speed;
    public float hp;

    public bool hasLanded;
    
    private float distanceToGround;
    private float xPosOfLandingPlatform;
    private bool mainThrusterIsOn;
    private float leftThrust = 0f, rightThrust = 0f;


    // Use this for initialization
    void Start()
    {
        hasLanded = false;
        mainThrusterIsOn = false;
        leftThrust = 0f;
        rightThrust = 0f;
        hp = 1;
        healthBar.value = hp;


        xPosOfLandingPlatform = UnityEngine.Random.Range(-25, 25); //Getting the random x place for the landing platform
        Vector3 pos = new Vector3(xPosOfLandingPlatform, theLandingSpot.transform.position.y, theLandingSpot.transform.position.z);
        theLandingSpot.transform.position = pos; //Setting the random value to the actual platform

    }

    internal void stopBooster()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

        //For ship landing!
        //hasLanded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        if (!shipActive)
        {
            if (Input.GetButton("Fire1_P1") || Input.GetButton("Fire1_P2"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (shipActive)
        {
            Health();
            distanceToGround = Mathf.Abs(groundCheckPoint.position.y - theLandingSpot.transform.position.y);

            hasLanded = theLandingSpot.transform.position.y + 4.8 >= groundCheckPoint.position.y;

            if (!hasLanded)
            {
                transform.Translate(0, -Time.deltaTime * speed, 0);
            }

            if (distanceToGround < 10) //and speed to fast
            {
                //Do something, like explode the ship, if players are landing too harsly
            }
            if (hasLanded)
            {
                if ((groundCheckPoint.transform.position.x > xPosOfLandingPlatform - 1.3) && (groundCheckPoint.transform.position.x < xPosOfLandingPlatform + 1.3) && (theLandingGear.open))
                {
                    completeText.SetActive(true);
                    //Debug.Log("You are safe, Congratz");
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
                    }
                }
            }
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
        leftThrust = Time.deltaTime * speed;
        rightThrust = 0;
    }
    public void LeftThrusterOff()
    {
        leftThrust = 0;
        rightThrust = 0;
    }
    public void RightThrusterOn()
    {
        rightThrust = -Time.deltaTime * speed;
        leftThrust = 0;
    }
    public void RightThrusterOff()
    {
        leftThrust = 0;
        rightThrust = 0;
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
                    theShip.transform.Translate(rightThrust + leftThrust, Time.deltaTime, 0);
                }
                boosterRight.GetComponent<Animator>().SetBool("boosterActive", true);
                theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
            }
            if (rightThrust + leftThrust > 0)
            {
                if (mainThrusterIsOn)
                {
                    mainThruster.GetComponent<Animator>().SetBool("thrusterActive", true);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterActive", true);
                    theShip.transform.Translate(rightThrust + leftThrust, Time.deltaTime, 0);
                }
                boosterLeft.GetComponent<Animator>().SetBool("boosterActive", true);
                theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
            }
            if (rightThrust + leftThrust == 0)
            {
                if (mainThrusterIsOn)
                {
                    mainThruster.GetComponent<Animator>().SetBool("thrusterActive", true);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterActive", false);
                    boosterRight.GetComponent<Animator>().SetBool("boosterActive", false);
                    theShip.transform.Translate(0, Time.deltaTime, 0);
                }

                theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
            }
        }

        

        //boosterOn = true;
        //theShip.transform.Translate(x, y, z); //move ship

    }

    public void StopBooster()
    {
        mainThruster.GetComponent<Animator>().SetBool("thrusterActive", false);
        boosterRight.GetComponent<Animator>().SetBool("boosterActive", false);
        boosterLeft.GetComponent<Animator>().SetBool("boosterActive", false);
    }

    public void BreakShip()
    {
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
                //hasLanded = true;
            }

        }
    }
    public void ShipIsHit()
    {
        hp -= 0.10f;
    }

}
