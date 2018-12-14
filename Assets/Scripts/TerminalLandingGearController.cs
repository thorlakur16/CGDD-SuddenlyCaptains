using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalLandingGearController : MonoBehaviour {

    public PlayerController thePlayer1;
    public PlayerController thePlayer2;
    public LandingGearController landingGear1;
    public LandingGearController landingGear2;
    public bool landingGearIsDown;
    public AudioClip landingGearDownSound;
    public AudioClip landingGearUpSound;
    AudioSource audioSource;
    public Volume volume;

    public ShipHandler theShip;
    Animator animator;
    public float activateLandingGearDistance;

    void Start () {
        volume = GameObject.FindObjectOfType<ShipHandler>().GetComponent<Volume>();
        foreach (PlayerController player in GameObject.FindObjectsOfType(typeof(PlayerController)))
        {
            if (player.name == "Player1")
            {
                thePlayer1 = player;
            }
            else if (player.name == "Player2")
            {
                thePlayer2 = player;
            }
        }

        foreach (LandingGearController gear in GameObject.FindObjectsOfType(typeof(LandingGearController)))
        {
            if (gear.name == "LandingGearRight")
            {
                landingGear1 = gear;
            }
            else if (gear.name == "LandingGearLeft")
            {
                landingGear2 = gear;
            }
        }
        landingGearIsDown = false;
        audioSource = GetComponent<AudioSource>();
        theShip = GameObject.FindObjectOfType<ShipHandler>();
        animator = GetComponent<Animator>();
        animator.SetBool("Activated", false);
    }

    // Update is called once per frame
    void Update()
    {

        audioSource.volume = volume.getAudioVolume();

        if (theShip.transform.position.y < activateLandingGearDistance)

        {
            if (!animator.GetBool("Activated"))
            {
                animator.SetBool("Activated", true);
                audioSource.Play();
            }

            if (thePlayer1.onTerminalLandingGear)
            {
                if (Input.GetButtonDown("Fire1_P1"))
                {
                    if (landingGearIsDown)
                    {
                        audioSource.clip = landingGearUpSound;
                        audioSource.PlayOneShot(landingGearUpSound, 0.4F);
                        landingGearIsDown = false;
                        landingGear1.LandingGearUp();
                        landingGear2.LandingGearUp();
                    }
                    else
                    {
                        audioSource.clip = landingGearDownSound;
                        audioSource.PlayOneShot(landingGearDownSound, 0.7F);
                        landingGearIsDown = true;
                        landingGear1.LandingGearDown();
                        landingGear2.LandingGearDown();
                    }
                }
            }
            if (thePlayer2.onTerminalLandingGear)
            {
                if (Input.GetButtonDown("Fire1_P2"))
                {
                    if (landingGearIsDown)
                    {
                        audioSource.clip = landingGearUpSound;
                        audioSource.PlayOneShot(landingGearUpSound, 0.4F);
                        landingGearIsDown = false;
                        landingGear1.LandingGearUp();
                        landingGear2.LandingGearUp();
                    }
                    else
                    {
                        audioSource.clip = landingGearDownSound;
                        audioSource.PlayOneShot(landingGearDownSound, 0.7F);
                        landingGearIsDown = true;
                        landingGear1.LandingGearDown();
                        landingGear2.LandingGearDown();
                    }
                }
            }
        }
    }
}