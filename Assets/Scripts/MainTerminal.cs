using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    public Animator animator;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (thePlayer1.onTerminalUp)
        {
            if(Input.GetButtonDown("Fire1_P1"))
            {
                if (theShip.mainThrusterIsOn)
                {
                    theShip.MainThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    theShip.MainThrusterOn();
                    animator.SetBool("TerminalOn", true);
                }
            }
            
        }
        if (thePlayer2.onTerminalUp)
        {
            if (Input.GetButtonDown("Fire1_P2"))
            {
                if (theShip.mainThrusterIsOn)
                {
                    theShip.MainThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    theShip.MainThrusterOn();
                    animator.SetBool("TerminalOn", true);
                }
            }
        }
    }
    
}
