using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour
{

    public GameObject boosterRight;
    public GameObject boosterLeft;
    public GameObject mainThruster;
    public GameObject theShip;

    public GameObject theLandingSpot;
    public GameObject completeText;
    public GameObject dieText;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public float speed;

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

        distanceToGround = Mathf.Abs(groundCheckPoint.position.y - theLandingSpot.transform.position.y);

        hasLanded = theLandingSpot.transform.position.y + 3.2 >= groundCheckPoint.position.y;
        
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
            if ((groundCheckPoint.transform.position.x > xPosOfLandingPlatform - 1.3) && (groundCheckPoint.transform.position.x < xPosOfLandingPlatform + 1.3))
            {
                completeText.SetActive(true);
                Debug.Log("You are safe, Congratz");
            }
            else
            {
                dieText.SetActive(true);
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
    }
    public void RightThrusterOn()
    {
        rightThrust = -Time.deltaTime * speed;
        leftThrust = 0;
    }
    public void RightThrusterOff()
    {
    }
    public void StartBooster()
    {
        Debug.Log("rightThrust: " + rightThrust + ", leftThrust: " + leftThrust + " = " + (rightThrust + leftThrust));
        if (mainThrusterIsOn)
        {
            mainThruster.GetComponent<Animator>().SetBool("thrusterActive", true);
            theShip.transform.Translate(0, Time.deltaTime, 0);
        }
        if (rightThrust + leftThrust < 0)
        {
            boosterRight.GetComponent<Animator>().SetBool("boosterActive", true);
            theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
        }
        if(rightThrust + leftThrust > 0)
        {
            boosterLeft.GetComponent<Animator>().SetBool("boosterActive", true);
            theShip.transform.Translate(rightThrust + leftThrust, 0, 0);
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
    
}
