using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    public Animator animator;
    public AudioClip onSound;
    public AudioClip offSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (thePlayer1.onTerminalUp)
        {
            if(Input.GetButtonDown("Fire1_P1"))
            {
                if (theShip.mainThrusterIsOn)
                {
                    audioSource.clip = offSound;
                    audioSource.PlayOneShot(offSound, 0.7F);
                    theShip.MainThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    audioSource.clip = onSound;
                    audioSource.PlayOneShot(onSound, 0.7F);
                    theShip.MainThrusterOn();
                    animator.SetBool("TerminalOn", true);
                }
            }
            
        }
        if (thePlayer2.onTerminalUp)
        {
            if (Input.GetButtonDown("Fire1_P2"))
            {
                if (theShip.mainThrusterIsOn)
                {
                    audioSource.clip = offSound;
                    audioSource.PlayOneShot(offSound, 0.7F);
                    theShip.MainThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    audioSource.clip = onSound;
                    audioSource.PlayOneShot(onSound, 0.7F);
                    theShip.MainThrusterOn();
                    animator.SetBool("TerminalOn", true);
                }
            }
        }
    }
    
}
