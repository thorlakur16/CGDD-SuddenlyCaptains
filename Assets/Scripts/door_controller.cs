using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_controller : MonoBehaviour {

    public player_controller thePlayer1;
    public player_controller thePlayer2;

    private bool player1IsHere;
    private bool player2IsHere;
    public Animator animator;
    public GameObject theDoor;
    public float timeOpen = 0f;
    public float force = 1f;
    public ShipHandler theShip;

	// Use this for initialization
	void Start () {
        player1IsHere = false;
        player2IsHere = false;
        animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(timeOpen > 0)
        {
            timeOpen--;
            //check if ship has landed
            if (!theShip.hasLanded)
            {
                thePlayer1.transform.Translate(Time.deltaTime * 1.5f, 0, 0);
            }
        }
        if (player1IsHere)
        {
            if (Input.GetButton("Fire1_P1"))
            {
                animator.SetTrigger("openDoor");
                animator.ResetTrigger("closeDoor");
                timeOpen = 60;
                theDoor.GetComponent<BoxCollider2D>().enabled = false;
                //check if ship has landed
                if (!theShip.hasLanded)
                {
                    thePlayer1.KillPlayer();
                }
            }
        }

        if (player2IsHere)
        {
            if (Input.GetButton("Fire1_P2"))
            {
                Debug.Log("here");
                animator.SetTrigger("openDoor");
                animator.ResetTrigger("closeDoor");
                timeOpen = 60;
                theDoor.GetComponent<BoxCollider2D>().enabled = false;
                //check if ship has landed
                if (!theShip.hasLanded)
                {
                    thePlayer2.KillPlayer();
                }
            }
        }
       

        if (timeOpen == 0)
        {
            theDoor.GetComponent<BoxCollider2D>().enabled = true;
            animator.SetTrigger("closeDoor");
            animator.ResetTrigger("openDoor");
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1")
        {
            player1IsHere = true;
        }
        if (collision.gameObject.name == "Player2")
        {
            player2IsHere = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            player1IsHere = false;
        }
        if (collision.gameObject.name == "Player2")
        {
            player2IsHere = false;
        }
    }
}
