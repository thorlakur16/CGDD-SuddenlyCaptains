using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminal2 : MonoBehaviour {

    private player_controller player1;
    private player_controller player2;


	// Use this for initialization
	void Start () {
        foreach (terminal2 terminal in GameObject.FindObjectsOfType(typeof(terminal2)))
        {
            //Debug.Log(terminal);
        }
        foreach (player_controller player in GameObject.FindObjectsOfType(typeof(player_controller)))
        {
            if(player.name == "Player1")
            {
                player1 = player;
            }
            else if(player.name == "Player2")
            {
                player2 = player;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player1")
        {
            if (name == "TerminalLeft")
            {
                player1.onTerminalLeft = true;
            }
            if (name == "TerminalRight")
            {
                player1.onTerminalRight = true;
            }
            if (name == "TerminalUp")
            {
                player1.onTerminalUp = true;
            }
            if (name == "TerminalBoost")
            {
                player1.onTerminalBooster = true;
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
            if (name == "TerminalUp")
            {
                player2.onTerminalUp = true;
            }
            if (name == "TerminalBoost")
            {
                player2.onTerminalBooster = true;
            }
            player2.onTerminal = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player1")
        {
            player1.onTerminal = false;
            player1.onTerminalLeft = false;
            player1.onTerminalRight = false;
            player1.onTerminalUp = false;
            player1.onTerminalBooster = false;
        }
        if (coll.gameObject.name == "Player2")
        {
            player2.onTerminal = false;
            player2.onTerminalLeft = false;
            player2.onTerminalRight = false;
            player2.onTerminalUp = false;
            player2.onTerminalBooster = false;
        }
    }

}
