using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;

    public GameObject boosterRight;
    public GameObject boosterLeft;
    public BoosterControl boosterMain;
    public bool playerIsUsingTerminal;
    
    // Use this for initialization
    void Start ()
    {
        playerIsUsingTerminal = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (thePlayer1.onTerminalBooster)
        {
            if (Input.GetButton("Fire1_P1"))
            {
                if (!playerIsUsingTerminal)
                {
                    playerIsUsingTerminal = true;
                    if (theShip.mainThrusterIsOn)
                    {
                        boosterMain.playSound();
                    }
                    theShip.StartBooster();
                }
               
            }
            if (Input.GetButtonUp("Fire1_P1"))
            {
                playerIsUsingTerminal = false;
                boosterMain.stopSound();
                theShip.StopBooster();
            }
        }
        if (thePlayer2.onTerminalBooster)
        {
            if (Input.GetButton("Fire1_P2"))
            {
                if(!playerIsUsingTerminal)
                {
                    playerIsUsingTerminal = true;
                    if (theShip.mainThrusterIsOn)
                    {
                        boosterMain.playSound();
                    }
                    theShip.StartBooster();
                }
              
            }
            if (Input.GetButtonUp("Fire1_P2"))
            {
                playerIsUsingTerminal = false;
                boosterMain.stopSound();
                theShip.StopBooster();
            }
        }
    }
}

