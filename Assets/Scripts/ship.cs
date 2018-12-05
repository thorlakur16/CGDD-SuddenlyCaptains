using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour {

    public float moveSpeed;
    bool hasLanded;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private booster_control theBooster;
    private float distanceToGround;
    private GameObject theLandingSpot;

    private Rigidbody2D theRB;

    private float xPosOfLandingPlatform;
    public bool boosterOn = false;
    private GameObject theShip;

    // Use this for initialization
    void Start ()
    {
        theShip = GameObject.Find("Ship");
        theRB = GetComponent<Rigidbody2D>();
        theBooster = FindObjectOfType<booster_control>();
        theLandingSpot = GameObject.FindGameObjectWithTag("Planet");
        xPosOfLandingPlatform = Random.Range(-25, 25);
        Vector3 pos = new Vector3(xPosOfLandingPlatform, theLandingSpot.transform.position.y, theLandingSpot.transform.position.z);
        theLandingSpot.transform.position = pos;
    }
	
	// Update is called once per frame
	void Update ()
    {
        hasLanded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        
        distanceToGround = Mathf.Abs(groundCheckPoint.position.y - theLandingSpot.transform.position.y);
        if (!hasLanded)
        {
            theRB.transform.Translate(0, -Time.deltaTime * moveSpeed, 0);
        } else if (distanceToGround < 10 && theRB.velocity.y > 5)
        {
            theRB.transform.Translate(Time.deltaTime, 0, 0);
        }
        theBooster = FindObjectOfType<booster_control>();
        foreach (booster_control booster in GameObject.FindObjectsOfType(typeof(booster_control)))
        {
            if (booster.name == "TerminalUp")
            {
                theBooster = booster;
            }
        }

    }
    public void startBooster(float x, float z, float y)
    {
        boosterOn = true;
        theShip.transform.Translate(x, y, z); //move ship
    }
    public void shutdownBooster()
    {
        Debug.Log("boosterOff in booster");
        boosterOn = false;
    }
}
