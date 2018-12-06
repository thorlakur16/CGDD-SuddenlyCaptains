using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    private PlayerController player1;
    private PlayerController player2;


    // Use this for initialization
    void Start()
    {
        foreach (PlayerController player in GameObject.FindObjectsOfType(typeof(PlayerController)))
        {
            if (player.name == "Player1")
            {
                player1 = player;
            }
            else if (player.name == "Player2")
            {
                player2 = player;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player1")
        {
            player1.onLadder = true;
        }
        if (collision.gameObject.name == "Player2")
        {
            player2.onLadder = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            player1.onLadder = false;
        }
        if (collision.gameObject.name == "Player2")
        {
            player2.onLadder = false;
        }
    }
}
