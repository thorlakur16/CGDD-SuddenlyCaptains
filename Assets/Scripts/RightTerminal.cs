using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public GameObject boosterRight;
    public GameObject boosterLeft;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (thePlayer1.onTerminalRight)
        {
            if (Input.GetButtonDown("Fire1_P1"))
            {
                if (theShip.rightThrusterIsOn)
                {
                    theShip.RightThrusterOff();
                    boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                }
                else
                {
                    theShip.RightThrusterOn();
                    boosterRight.GetComponent<Animator>().SetBool("boosterOn", true);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                }
            }

        }
        if (thePlayer2.onTerminalRight)
        {
            if (Input.GetButtonDown("Fire1_P2"))
            {
                if (theShip.rightThrusterIsOn)
                {
                    theShip.RightThrusterOff();
                    boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                }
                else
                {
                    theShip.RightThrusterOn();
                    boosterRight.GetComponent<Animator>().SetBool("boosterOn", true);
                    boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                }
            }
        }
    }
}

