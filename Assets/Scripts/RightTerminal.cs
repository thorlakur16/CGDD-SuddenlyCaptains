using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public Animator animator;
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
                theShip.leftThrusterIsOn = false;
                if (theShip.rightThrusterIsOn)
                {
                    theShip.RightThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    theShip.RightThrusterOn();                    
                    animator.SetBool("TerminalOn", true);
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
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    theShip.RightThrusterOn();
                    animator.SetBool("TerminalOn", true);
                }
            }
        }
    }
}

