using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour {
    private string player_nr;
    public Animator animator;
    private Rigidbody2D body;
    public float speed;
    public bool onTerminal = false;
    public bool onTerminalLeft = false;
    public bool onTerminalRight = false;
    public bool onTerminalUp = false;
    public bool onTerminalBooster = false;
    public bool onLadder = false;
    public float size = 1;
    private float gravityScale;
    private GameObject theShip;
    private booster_control theBooster;

    private bool alive = true;

    public float boosterX;
    public float boosterY;

    // Use this for initialization
    void Start () {
        player_nr = name.Replace("Player", "");
        body = gameObject.GetComponent<Rigidbody2D>();
        gravityScale = body.gravityScale;
        theShip = GameObject.Find("Ship");
        theBooster = FindObjectOfType<booster_control>();
        boosterX = 0;
        boosterY = 0;
    }
	// Update is called once per frame
	void Update () {
        
        if (alive)
        {
            float horizontal = Input.GetAxis("Horizontal_P" + player_nr); //horizontal movement
            //float horizontal = Input.GetAxis("Horizontal"); //horizontal movement with keyboard
            DoFire1Things();
            DoFire2Things();


            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            if (onTerminal == true && animator.GetBool("onTerminal") != true)
            {
                animator.SetBool("onTerminal", true); //play animation onTerminal idle
            }
            if (onTerminal == false && animator.GetBool("onTerminal") != false)
            {
                animator.SetBool("onTerminal", false); //stop playing animation onTerminal idle
            }

            float vertical = 0;
            if (onLadder)
            {
                body.gravityScale = 0f; //set gravity to 0
                vertical = Input.GetAxis("Vertical_P" + player_nr); //get vertical movement
                //vertical = Input.GetAxis("Vertical"); //get vertical movement with keyboard

                if (animator.GetBool("onLadder") != true)
                {
                    animator.SetBool("onLadder", true); //play onLadder animation
                }
            }
            if (!onLadder && animator.GetBool("onLadder") != false)
            {
                body.gravityScale = gravityScale; //reset gravity
                animator.SetBool("onLadder", false);
            }

            animator.SetFloat("VertSpeed", Mathf.Abs(vertical)); //set vertical speed in animator

            horizontal *= Time.deltaTime * speed; //calculate horizontal movement
            vertical *= Time.deltaTime * speed; //calculate vertical movement

            DoAFlip(horizontal);

            transform.Translate(horizontal, vertical, 0); //move the player
        }
        
		
	}

    private void DoFire1Things()
    {
        if (Input.GetButton("Fire1_P" + player_nr) //the A button   Input.GetButton("Fire1") fyrir keyboard control
        {
            if (animator.GetBool("pushTerminal") != true)
            {
                animator.SetBool("pushTerminal", true);
            }
            if (onTerminalLeft)
            { 
                //theBooster.startBooster(-Time.deltaTime, 0, 0); //start booster
                //boosterX = -Time.deltaTime;
                //boosterY = 0;
            }
            if (onTerminalRight)
            {
                //theShip.transform.Translate(0, Time.deltaTime, 0); //move ship
                //theBooster.startBooster(Time.deltaTime, 0, 0); //start booster
                //boosterX = Time.deltaTime;
                //boosterY = 0;
            }
            if (onTerminalUp)
            {
                //theShip.transform.Translate(0, Time.deltaTime, 0); //move ship
                //theBooster.startBooster(0, Time.deltaTime, 0); //start booster
                //boosterX = 0;
                //boosterY = Time.deltaTime;

            }
            if (onTerminalBooster)
            {
                //theShip.transform.Translate(0, Time.deltaTime, 0); //move ship
                //Debug.Log(boosterX + "---" + boosterY);
                //theBooster.startBooster(boosterX, boosterY, 0); //start booster
            }
        }
        if ((Input.GetButtonUp("Fire1_P" + player_nr) || Input.GetButtonUp("Fire1")) && animator.GetBool("pushTerminal") != false)
        {
            animator.SetBool("pushTerminal", false); //play push terminal animation
            //theBooster.shutdownBooster(); //shutdown booster
        }
    }

    private void DoFire2Things()
    {
        if (Input.GetButton("Fire2_P" + player_nr)) // the B button
        {
            //animator.SetTrigger("KillSwitch"); //to play death animation
            if (animator.GetBool("pushTerminal") != true)
            {
                animator.SetBool("pushTerminal", true); //play push terminal animation
            }
            if (onTerminal)
            {
                theShip.transform.Translate(0, -Time.deltaTime, 0); //move ship
            }
        }
        if (Input.GetButtonUp("Fire2_P" + player_nr) && animator.GetBool("pushTerminal") != false)
        {
            animator.SetBool("pushTerminal", false); //stop playing push terminal animation
        }
    }

    void DoAFlip(float horizontal)
    {
        //code to flip the player when going left or right
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z);
        }
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(-size, transform.localScale.y, transform.localScale.z);
        }
    }

    public void KillPlayer()
    {
        alive = false;
    }
}
