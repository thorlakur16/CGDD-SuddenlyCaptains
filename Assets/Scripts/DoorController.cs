using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    
    public Animator animator;
    public GameObject theDoor;
    public float timeOpen = 0f;
    public float force = 1f;
    public ShipHandler theShip;
    private bool doorOpen;


    public AudioClip impact;
    AudioSource audioSource;
    public Volume volume;


    // Use this for initialization
    void Start ()
    {
        volume = GameObject.FindObjectOfType<ShipHandler>().GetComponent<Volume>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        audioSource.volume = volume.getAudioVolume();
        if (timeOpen > 0)
        {
            timeOpen--;
            //check if ship has landed
            if (!theShip.hasLanded && thePlayer1.onDoor)
            {
                thePlayer1.transform.Translate(Time.deltaTime * 1.5f, 0, 0);
            }
            if (!theShip.hasLanded && thePlayer2.onDoor)
            {
                thePlayer2.transform.Translate(Time.deltaTime * 2f, 0, 0);
            }
        }
        if (thePlayer1.onDoor)
        {
            

            if (Input.GetButtonDown("Fire1_P1"))
            {
                audioSource.PlayOneShot(impact, 0.7F);
                animator.SetTrigger("openDoor");
                doorOpen = true;
                animator.ResetTrigger("closeDoor");
                timeOpen = 50;
                theDoor.GetComponent<BoxCollider2D>().enabled = false;
                //check if ship has landed
                if (!theShip.hasLanded)
                {
                    Rigidbody2D body = thePlayer1.GetComponent<Rigidbody2D>();
                    body.gravityScale = -0.1f;
                    body.AddForce(transform.right * 10);

                    thePlayer1.KillPlayer();
                }
            }
        }

        if (thePlayer2.onDoor)
        {
            
            if (Input.GetButtonDown("Fire1_P2"))
            {
                audioSource.PlayOneShot(impact, 0.7F);
                animator.SetTrigger("openDoor");
                animator.ResetTrigger("closeDoor");
                doorOpen = true;
                timeOpen = 60;
                theDoor.GetComponent<BoxCollider2D>().enabled = false;
                //check if ship has landed
                if (!theShip.hasLanded)
                {
                    Rigidbody2D body = thePlayer2.GetComponent<Rigidbody2D>();
                    body.gravityScale = -0.1f;
                    body.AddForce(transform.right * 10);
                    thePlayer2.KillPlayer();
                }
            }
        }
       

        if (timeOpen == 0 && doorOpen == true)
        {
            theDoor.GetComponent<BoxCollider2D>().enabled = true;
            if(doorOpen == true)
            {
                doorOpen = false;
                animator.SetTrigger("closeDoor");
                animator.ResetTrigger("openDoor");
                audioSource.PlayOneShot(impact, 0.5F);
            }
        }


	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player1")
        {
            thePlayer1.onDoor = true;
        }
        if (collision.gameObject.name == "Player2")
        {
            thePlayer2.onDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.name == "Player1")
        {
            thePlayer1.onDoor = false;
        }
        if (collision.gameObject.name == "Player2")
        {
            thePlayer2.onDoor = false;
        }
    }
}
