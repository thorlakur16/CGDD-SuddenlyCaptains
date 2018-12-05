using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour {

    public GameObject boosterRight;
    public GameObject boosterLeft;
    public GameObject mainThruster;
    public GameObject theShip;
    public GameObject theLandingSpot;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public float speed;

    private bool hasLanded;
    //private Rigidbody2D theRB;
    private float distanceToGround;
    private float xPosOfLandingPlatform;
    private bool mainThrusterIsOn;
    private float x;
    
    
    // Use this for initialization
    void Start () {
        mainThrusterIsOn = false;
        x = 0;
        speed = 2;

        //theRB = GetComponent<Rigidbody2D>();
        xPosOfLandingPlatform = Random.Range(-25, 25); //Getting the random x place for the landing platform
        Vector3 pos = new Vector3(xPosOfLandingPlatform, theLandingSpot.transform.position.y, theLandingSpot.transform.position.z);
        theLandingSpot.transform.position = pos; //Setting the random value to the actual platform
    }
	
	// Update is called once per frame
	void Update () {

        //For ship landing!
        hasLanded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        distanceToGround = Mathf.Abs(groundCheckPoint.position.y - theLandingSpot.transform.position.y);
        if (!hasLanded)
        {
            transform.Translate(0, -Time.deltaTime * speed, 0);
        }
        else if (distanceToGround < 10) //and speed to fast
        {
            //Do something, like explode the ship, if players are landing too harsly
        }
    }
    public void MainThrusterOn()
    {

        mainThrusterIsOn = true;
    }
    public void MainThrusterOff()
    {

        mainThrusterIsOn = false;
    }
    public void LeftThrusterOn()
    {

        x = Time.deltaTime * speed;
    }
    public void LeftThrusterOff()
    {

        x = 0;
    }
    public void RightThrusterOn()
    {

        x = -Time.deltaTime * speed;
    }
    public void RightThrusterOff()
    {

        x = 0;
    }
    public void startBooster()
    {
        if(mainThrusterIsOn)
        {
            theShip.transform.Translate(x, Time.deltaTime, 0);
        }
        else
        {
            theShip.transform.Translate(x, 0, 0);
        }
        //boosterOn = true;
        //theShip.transform.Translate(x, y, z); //move ship
    }
}
