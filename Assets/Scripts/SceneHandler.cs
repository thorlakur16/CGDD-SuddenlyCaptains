using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

    //muna að gera skip function til að skippa þessu cutscene

    public GameObject janitor;
    public GameObject captain;
    public GameObject captainRagdoll;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject fire4;
    public GameObject fire5;

    public Text nameText;
    public Text dialogText;

    GameObject captainImage;
    GameObject firstOfficerImage;
    GameObject medicalOfficerImage;


    public AudioClip captainTalkingSound;
    public AudioClip janitorTalkingSound;
    AudioSource audioSource;

    public GameObject explosion;
    public AudioClip explosionSound;

    public float timer;
    // Use this for initialization
    void Start () {
        captainImage = GameObject.Find("CaptainImage");
        firstOfficerImage = GameObject.Find("FirstOffImage");
        medicalOfficerImage = GameObject.Find("MedOffImage");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

        //skip the scene.
        if (Input.GetButtonDown("Restart_P1") || Input.GetButtonDown("Restart_P2"))
        {
            timer = 3500;
        }


        if (timer == 0)
        {
            audioSource.clip = captainTalkingSound;
            audioSource.volume = 0.4f;
            audioSource.Play();
            captain.GetComponent<Animator>().SetBool("isTalking", true);
            janitor.GetComponent<Animator>().SetBool("isTalking", false);
            nameText.text = "Richard D. Handsome, Captain";
            dialogText.text = "The victory party will be held in the bridge tonight.";
        }
        if(timer == 250)
        {
            audioSource.Pause();
            audioSource.clip = janitorTalkingSound;
            audioSource.volume = 0.4f;
            audioSource.Play();
            captain.GetComponent<Animator>().SetBool("isTalking", false);
            janitor.GetComponent<Animator>().SetBool("isTalking", true);
            nameText.text = "Gordon Fabio Riviera, Janitor";
            dialogText.text = "That sounds nice, should we bring something to the party?";
        }
        if (timer == 500)
        {
            audioSource.Pause();
            audioSource.clip = captainTalkingSound;
            audioSource.volume = 0.4f;
            audioSource.Play();
            captain.GetComponent<Animator>().SetBool("isTalking", true);
            janitor.GetComponent<Animator>().SetBool("isTalking", false);
            nameText.text = "Richard D. Handsome, Captain";
            dialogText.text = "The party is only for people who matter. You guys are not invited because the toilets are clogged and that requires your attention.";
        }
        if (timer == 1000)
        {
            audioSource.Pause();
            audioSource.clip = janitorTalkingSound;
            audioSource.volume = 0.4f;
            audioSource.Play();
            captain.GetComponent<Animator>().SetBool("isTalking", false);
            janitor.GetComponent<Animator>().SetBool("isTalking", true);
            nameText.text = "Gordon Fabio Riviera, Janitor";
            dialogText.text = "That does not sound very fair. Maybe we could attend the party after we finish cleaning the toilets?";
        }
        if (timer == 1250)
        {
            audioSource.Pause();
            audioSource.clip = captainTalkingSound;
            audioSource.volume = 0.4f;
            audioSource.Play();
            captain.GetComponent<Animator>().SetBool("isTalking", true);
            janitor.GetComponent<Animator>().SetBool("isTalking", false);
            nameText.text = "Richard D. Handsome, Captain";
            dialogText.text = "Life is not fair. You guys smell bad and nobody likes you anyway. Now stop pestering me pesant.";
        }
        if (timer == 1500)
        {
            audioSource.Pause();
            captain.GetComponent<Animator>().SetBool("isTalking", false);
            janitor.GetComponent<Animator>().SetBool("isTalking", false);
            nameText.text = "Gordon Fabio Riviera, Janitor";
            dialogText.text = "...";
        }
        if (timer == 1750)
        {
            audioSource.volume = 0.4f;
            audioSource.UnPause();
            captain.GetComponent<Animator>().SetBool("isTalking", true);
            janitor.GetComponent<Animator>().SetBool("isTalking", false);
            nameText.text = "Richard D. Handsome, Captain";
            dialogText.text = "That will be all.";
        }
        if(timer > 2000 && timer < 2250)
        {
            captain.GetComponent<Animator>().SetBool("isTalking", false);
            janitor.GetComponent<Animator>().SetBool("isTalking", false);
            nameText.text = "";
            dialogText.text = "";
            audioSource.Pause();
            float step = 2 * Time.deltaTime;
            captainImage.transform.position = Vector3.MoveTowards(captainImage.transform.position, new Vector3(9f, 0.8f, 0f), step);
            firstOfficerImage.transform.position = Vector3.MoveTowards(firstOfficerImage.transform.position, new Vector3(11f, 0.8f, 0f), step);
            medicalOfficerImage.transform.position = Vector3.MoveTowards(medicalOfficerImage.transform.position, new Vector3(7f, 0.8f, 0f), step);

        }
        if(timer < 2750 && timer > 2250)
        {
            if(timer < 2300 && timer > 2250)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, 0.2f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, 0.2f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, 0.2f));
            }
            if(timer < 2350 && timer > 2300)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
            }
            if (timer < 2400 && timer > 2350)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, 0.4f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, 0.4f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, 0.4f));
            }
            if (timer < 2450 && timer > 2400)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
            }
            if (timer < 2500 && timer > 2450)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, 0.4f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, 0.4f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, 0.4f));
            }
            if (timer < 2550 && timer > 2500)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
            }
            if (timer < 2600 && timer > 2550)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, 0.4f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, 0.4f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, 0.4f));
            }
            if (timer < 2650 && timer > 2600)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
            }
            if (timer < 2700 && timer > 2650)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, 0.4f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, 0.4f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, 0.4f));
            }
            if (timer < 2750 && timer > 2700)
            {
                captainImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                firstOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
                medicalOfficerImage.transform.Rotate(new Vector3(0, 0, -0.4f));
            }
        }
        if(timer == 2750)
        {
            explodeBridge();
        }
        if(timer > 2750 && timer < 3000)
        {
            float step = 10 * Time.deltaTime;
            firstOfficerImage.transform.position = Vector3.MoveTowards(firstOfficerImage.transform.position, new Vector3(-11f, 20, 0f), step);
            medicalOfficerImage.transform.position = Vector3.MoveTowards(medicalOfficerImage.transform.position, new Vector3(0f, 20, 0f), step);
            firstOfficerImage.transform.Rotate(new Vector3(0, 0, 20));
            medicalOfficerImage.transform.Rotate(new Vector3(0, 0, -20));
            captainImage.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            captainRagdoll.SetActive(true);
            fire1.SetActive(true);
            fire2.SetActive(true);
            fire3.SetActive(true);
            fire4.SetActive(true);
            fire5.SetActive(true);
            captain.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(timer > 3000 && timer < 3250)
        {
            captain.GetComponent<Animator>().SetBool("isTalking", false);
            janitor.GetComponent<Animator>().SetBool("isTalking", false);
            nameText.text = "Gordon Fabio Riviera, Janitor";
            dialogText.text = ":O";
        }
        if (timer > 3250 && timer < 3500)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(janitorTalkingSound, 1f);
            }
            captain.GetComponent<Animator>().SetBool("isTalking", false);
            janitor.GetComponent<Animator>().SetBool("isTalking", true);
            nameText.text = "Gordon Fabio Riviera, Janitor";
            dialogText.text = "Ohh no! The captain is dead... we will have to work together to land this ship safely. Let's get to it.";
        }
        if(timer == 3500)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Goto next scene");
        }
        
        timer++;
    }

    void explodeBridge()
    {
        Instantiate(explosion, new Vector3(8, 0.8f, 0), Quaternion.identity);
        Instantiate(explosion, new Vector3(9, 0.7f, 0), Quaternion.identity);
        Instantiate(explosion, new Vector3(8.7f, 0.82f, 0), Quaternion.identity);
        Instantiate(explosion, new Vector3(10, 0.62f, 0), Quaternion.identity);
        audioSource.clip = explosionSound;
        audioSource.PlayOneShot(explosionSound, 1f);
        Instantiate(explosion, new Vector3(11.7f, 0.75f, 0), Quaternion.identity);
        Instantiate(explosion, new Vector3(11, 0.88f, 0), Quaternion.identity);
        Instantiate(explosion, new Vector3(7, 0.75f, 0), Quaternion.identity);
    }
}
