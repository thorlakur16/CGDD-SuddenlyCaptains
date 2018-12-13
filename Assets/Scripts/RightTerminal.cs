using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public Animator animator;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    public AudioClip onSound;
    public AudioClip offSound;
    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer1.onTerminalRight)
        {
            if (Input.GetButtonDown("Fire1_P1"))
            {
                theShip.leftThrusterIsOn = false;
                if (theShip.rightThrusterIsOn)
                {
                    audioSource.clip = offSound;
                    audioSource.PlayOneShot(offSound, 0.7F);
                    theShip.RightThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    audioSource.clip = onSound;
                    audioSource.PlayOneShot(onSound, 0.7F);
                    theShip.RightThrusterOn();                    
                    animator.SetBool("TerminalOn", true);
                }
            }

        }
        if (thePlayer2.onTerminalRight)
        {
            if (Input.GetButtonDown("Fire1_P2"))
            {
                if (theShip.rightThrusterIsOn)
                {
                    audioSource.clip = offSound;
                    audioSource.PlayOneShot(offSound, 0.7F);
                    theShip.RightThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    audioSource.clip = onSound;
                    audioSource.PlayOneShot(onSound, 0.7F);
                    theShip.RightThrusterOn();
                    animator.SetBool("TerminalOn", true);
                }
            }
        }
    }
}

