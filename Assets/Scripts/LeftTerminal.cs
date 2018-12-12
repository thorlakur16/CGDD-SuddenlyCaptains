using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    public Animator animator;
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
                theShip.rightThrusterIsOn = false;
                if (theShip.leftThrusterIsOn)
                {
                    theShip.LeftThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    theShip.LeftThrusterOn();
                    animator.SetBool("TerminalOn", true);
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
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    theShip.LeftThrusterOn();
                    animator.SetBool("TerminalOn", true);
                }
            }
        }
    }
}