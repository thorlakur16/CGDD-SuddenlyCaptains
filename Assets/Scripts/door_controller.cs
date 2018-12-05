using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_controller : MonoBehaviour {

    public player_controller thePlayer1;
    public player_controller thePlayer2;
    public Animator animator;
    public GameObject theDoor;
    public float timeOpen = 0f;
    public float force = 1f;

	// Use this for initialization
	void Start () {
        animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(timeOpen > 0)
        {
            timeOpen--;
            thePlayer1.transform.Translate(Time.deltaTime * 1.5f, 0, 0);
        }
        if (Input.GetButton("Fire1_P1"))
        {
            animator.SetTrigger("openDoor");
            animator.ResetTrigger("closeDoor");
            timeOpen = 60;
            theDoor.GetComponent<BoxCollider2D>().enabled = false;
            thePlayer1.KillPlayer();
        }

        if(timeOpen == 0)
        {
            theDoor.GetComponent<BoxCollider2D>().enabled = true;
            animator.SetTrigger("closeDoor");
            animator.ResetTrigger("openDoor");
        }

	}
}
