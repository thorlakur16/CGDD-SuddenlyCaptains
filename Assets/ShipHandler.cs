using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour {

    public GameObject boosterRight;
    public GameObject boosterLeft;
    public GameObject mainThruster;
    public GameObject theShip;
    private bool mainThrusterIsOn;
    private float x;
    private float speed;
    
    // Use this for initialization
    void Start () {
        mainThrusterIsOn = false;
        x = 0;
        speed = 2;
	}
	
	// Update is called once per frame
	void Update () {
		
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
