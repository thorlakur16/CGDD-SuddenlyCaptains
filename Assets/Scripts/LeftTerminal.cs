using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    public GameObject boosterLeft;
    public GameObject boosterRight;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (thePlayer1.onTerminalLeft)
        {
            if (Input.GetButtonDown("Fire1_P1"))
            {
                if (theShip.leftThrusterIsOn)
                {
                    theShip.LeftThrusterOff();
                    boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                }
                else
                {
                    theShip.LeftThrusterOn();
                    boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterOn", true);
                }
            }
        }
        if (thePlayer2.onTerminalLeft)
        {
            if (Input.GetButtonDown("Fire1_P2"))
            {
                if (theShip.leftThrusterIsOn)
                {
                    theShip.LeftThrusterOff();
                    boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                }
                else
                {
                    theShip.LeftThrusterOn();
                    boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterOn", true);
                }
            }
        }
    }
}