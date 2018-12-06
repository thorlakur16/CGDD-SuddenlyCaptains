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
            if (Input.GetButton("Fire1_P1"))
            {
                boosterRight.GetComponent<Animator>().SetBool("boosterOn", true);
                boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                theShip.RightThrusterOn();

            }
            if (Input.GetButton("Fire2_P1"))
            {
                boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                theShip.RightThrusterOff();

            }

        }
        if (thePlayer2.onTerminalRight)
        {
            if (Input.GetButton("Fire1_P2"))
            {
                boosterRight.GetComponent<Animator>().SetBool("boosterOn", true);
                boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                theShip.RightThrusterOn();
            }
            if (Input.GetButton("Fire2_P2"))
            {
                boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                boosterLeft.GetComponent<Animator>().SetBool("boosterOn", false);
                theShip.RightThrusterOff();

            }
        }
    }
}

