﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalLandingGearController : MonoBehaviour {

    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    public LandingGearController landingGear1;
    public LandingGearController landingGear2;
    public bool landingGearIsDown;
	// Use this for initialization
	void Start () {
        foreach (PlayerController player in GameObject.FindObjectsOfType(typeof(PlayerController)))
        {
            if (player.name == "Player1")
            {
                thePlayer1 = player;
            }
            else if (player.name == "Player2")
            {
                thePlayer2 = player;
            }
        }

        foreach (LandingGearController gear in GameObject.FindObjectsOfType(typeof(LandingGearController)))
        {
            if (gear.name == "LandingGearRight")
            {
                landingGear1 = gear;
            }
            else if (gear.name == "LandingGearLeft")
            {
                landingGear2 = gear;
            }
        }
        landingGearIsDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer1.onTerminalLandingGear)
        {
            if (Input.GetButtonDown("Fire1_P1"))
            {
                if (landingGearIsDown)
                {
                    landingGearIsDown = false;
                    landingGear1.LandingGearUp();
                    landingGear2.LandingGearUp();
                }
                else
                {
                    landingGearIsDown = true;
                    landingGear1.LandingGearDown();
                    landingGear2.LandingGearDown();
                }
            }
        }
        if (thePlayer2.onTerminalLandingGear)
        {
            if (Input.GetButtonDown("Fire1_P2"))
            {
                if (landingGearIsDown)
                {
                    landingGearIsDown = false;
                    landingGear1.LandingGearUp();
                    landingGear2.LandingGearUp();
                }
                else
                {
                    landingGearIsDown = true;
                    landingGear1.LandingGearDown();
                    landingGear2.LandingGearDown();
                }
            }
        }
    }
}