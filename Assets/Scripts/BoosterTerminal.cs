﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public player_controller thePlayer1;
    public player_controller thePlayer2;

    public GameObject boosterRight;

    public GameObject boosterLeft;

    public booster_control boosterMain;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(thePlayer1.onTerminalBooster);
        if (thePlayer1.onTerminalBooster)
        {
            if (Input.GetButton("Fire1_P1"))
            {
                theShip.StartBooster();
            }
            if (Input.GetButtonUp("Fire1_P1"))
            {
                theShip.StopBooster();
            }
        }
        if (thePlayer2.onTerminalBooster)
        {
            if (Input.GetButton("Fire1_P2"))
            {
                theShip.StartBooster();
            }
            if (Input.GetButtonUp("Fire1_P2"))
            {
                theShip.StopBooster();
            }
        }
    }
}

