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
    public bool player1IsUsingTerminal;
    public bool player2IsUsingTerminal;

    // Use this for initialization
    void Awake ()
    {
        player1IsUsingTerminal = false;
        player2IsUsingTerminal = false;
    }
	
	// Update is called once per frame
	void Update () {
        

        if (thePlayer1.onTerminalBooster)
        {
            if (!player2IsUsingTerminal)
            {
                if (Input.GetButton("Fire1_P1"))
                {
                    player1IsUsingTerminal = true;
                    if (theShip.mainThrusterIsOn)
                    {
                        boosterMain.playSound();
                    }
                    theShip.StartBooster();
                }
                if (Input.GetButtonUp("Fire1_P1"))
                {
                    player1IsUsingTerminal = false;
                    boosterMain.stopSound();
                    theShip.StopBooster();
                }
            }
        }
        
        if (thePlayer2.onTerminalBooster)
        {
            if (!player1IsUsingTerminal)
            {
                if (Input.GetButton("Fire1_P2"))
                {
                        player2IsUsingTerminal = true;
                        if (theShip.mainThrusterIsOn)
                        {
                            boosterMain.playSound();
                        }
                        theShip.StartBooster();
                }
                if (Input.GetButtonUp("Fire1_P2"))
                {
                    player2IsUsingTerminal = false;
                    boosterMain.stopSound();
                    theShip.StopBooster();
                }
            }
        }
    }
}

