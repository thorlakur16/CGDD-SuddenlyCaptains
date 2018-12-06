using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    public GameObject boosterLeft;
    public GameObject boosterRight;
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
                boosterLeft.GetComponent<Animator>().SetBool("boosterOn", true);
                boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                theShip.LeftThrusterOn();
            }
        }
        if (thePlayer2.onTerminalLeft)
        {
            if (Input.GetButton("Fire1_P2"))
            {                                   
                boosterLeft.GetComponent<Animator>().SetBool("boosterOn", true);
                boosterRight.GetComponent<Animator>().SetBool("boosterOn", false);
                theShip.LeftThrusterOn();                  
            }
        }
    }
}
