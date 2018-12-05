using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalLandingGearController : MonoBehaviour {

    public LandingGearController landingGear1;
    //public LandingGearController landingGear2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1_P1"))
        {
            if (landingGear1.isOpen())
            {
                landingGear1.LandingGearUp();
            }
            else
            {
                landingGear1.LandingGearDown();
            }
        }
        if (Input.GetButton("Fire1_P2"))
        {
            if (landingGear1.isOpen())
            {
                landingGear1.LandingGearUp();
            }
            else
            {
                landingGear1.LandingGearDown();
            }
        }
    }
}
