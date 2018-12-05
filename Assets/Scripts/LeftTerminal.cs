using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public player_controller thePlayer1;
    public player_controller thePlayer2;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (thePlayer1.onTerminalLeft)
        {
            if (Input.GetButton("Fire1_P1"))
            {
                theShip.LeftThrusterOn();
            }
        }
        if (thePlayer2.onTerminalLeft)
        {
            if (Input.GetButton("Fire1_P2"))
            {
                theShip.LeftThrusterOn();
            }
        }
    }
}
