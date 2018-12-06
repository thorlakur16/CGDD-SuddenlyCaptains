using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{

    public PlayerController player1;
    public PlayerController player2;


    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player1")
        {
            if (name == "TerminalLeft")
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                player1.onTerminalLeft = true;
            }
            if (name == "TerminalRight")
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                player1.onTerminalRight = true;
            }
            if (name == "TerminalMain")
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                player1.onTerminalUp = true;
            }
            if (name == "TerminalBooster")
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                player1.onTerminalBooster = true;
            }
            if (name == "TerminalLandingGear")
            {
                transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                player1.onTerminalLandingGear = true;
            }
            player1.onTerminal = true;
        }
        if (coll.gameObject.name == "Player2")
        {
            if (name == "TerminalLeft")
            {
                player2.onTerminalLeft = true;
            }
            if (name == "TerminalRight")
            {
                player2.onTerminalRight = true;
            }
            if (name == "TerminalMain")
            {
                player2.onTerminalUp = true;
            }
            if (name == "TerminalBooster")
            {
                player2.onTerminalBooster = true;
            }
            if (name == "TerminalLandingGear")
            {
                player2.onTerminalLandingGear = true;
            }

            player2.onTerminal = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player1")
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            player1.onTerminal = false;
            player1.onTerminalLeft = false;
            player1.onTerminalRight = false;
            player1.onTerminalUp = false;
            player1.onTerminalBooster = false;
            player1.onTerminalLandingGear = false;
        }
        if (coll.gameObject.name == "Player2")
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            player2.onTerminal = false;
            player2.onTerminalLeft = false;
            player2.onTerminalRight = false;
            player2.onTerminalUp = false;
            player2.onTerminalBooster = false;
            player2.onTerminalLandingGear = false;
        }
    }

}
