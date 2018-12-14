using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTerminal : MonoBehaviour {
    public ShipHandler theShip;
    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    public Animator animator;
    public AudioClip onSound;
    public AudioClip offSound;
    AudioSource audioSource;
    public Volume volume;
    // Use this for initialization
    void Start ()
    {
        volume = GameObject.FindObjectOfType<ShipHandler>().GetComponent<Volume>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volume.getAudioVolume();
        if (thePlayer1.onTerminalLeft)
        {
            if (Input.GetButtonDown("Fire1_P1"))
            {
                theShip.rightThrusterIsOn = false;
                if (theShip.leftThrusterIsOn)
                {
                    audioSource.clip = offSound;
                    audioSource.PlayOneShot(offSound, 0.7F);
                    theShip.LeftThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    audioSource.clip = onSound;
                    audioSource.PlayOneShot(onSound, 0.7F);
                    theShip.LeftThrusterOn();
                    animator.SetBool("TerminalOn", true);
                }
            }
        }
        if (thePlayer2.onTerminalLeft)
        {
            if (Input.GetButtonDown("Fire1_P2"))
            {
                if (theShip.leftThrusterIsOn)
                {
                    audioSource.clip = offSound;
                    audioSource.PlayOneShot(offSound, 0.7F);
                    theShip.LeftThrusterOff();
                    animator.SetBool("TerminalOn", false);
                }
                else
                {
                    audioSource.clip = onSound;
                    audioSource.PlayOneShot(onSound, 0.7F);
                    theShip.LeftThrusterOn();
                    animator.SetBool("TerminalOn", true);
                }
            }
        }
    }
}