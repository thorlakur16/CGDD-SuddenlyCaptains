using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(thePlayer1.onTerminalUp);
        if (thePlayer1.onTerminalUp)
        {
            if(Input.GetButton("Fire1_P1"))
            {
                Debug.Log("p2 pushed terminal boosoter");
                theShip.MainThrusterOn();
            }
            if (Input.GetButton("Fire2_P1"))
            {
                theShip.MainThrusterOff();
            }
        }
        if (thePlayer2.onTerminalUp)
        {
            if (Input.GetButton("Fire1_P2"))
            {
                Debug.Log("p2 pushed terminal boosoter");
                theShip.MainThrusterOn();
            }
            if (Input.GetButton("Fire2_P2"))
            {
                theShip.MainThrusterOff();
            }
        }
    }
    
}
