using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalLandingGearController : MonoBehaviour {

    public player_controller thePlayer1;
    public player_controller thePlayer2;
    public LandingGearController landingGear1;
    public LandingGearController landingGear2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (thePlayer1.onTerminalLandingGear)
        {
            if (Input.GetButton("Fire1_P1"))
            {
                landingGear1.LandingGearDown();
                landingGear2.LandingGearDown();
            }
        }
        if (thePlayer2.onTerminalLandingGear)
        {
            if (Input.GetButton("Fire1_P2"))
            {
                landingGear1.LandingGearDown();
                landingGear2.LandingGearDown();
            }
        }
        
    }
}
