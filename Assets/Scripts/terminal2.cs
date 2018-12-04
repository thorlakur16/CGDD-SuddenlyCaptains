using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminal2 : MonoBehaviour {

    private player_controller player1;
    private player_controller player2;


	// Use this for initialization
	void Start () {
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
            player1.onTerminal = true;
        }
        if (coll.gameObject.name == "Player2")
        {
            player2.onTerminal = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player1")
        {
            player1.onTerminal = false;
        }
        if (coll.gameObject.name == "Player2")
        {
            player2.onTerminal = false;
        }
    }

}
