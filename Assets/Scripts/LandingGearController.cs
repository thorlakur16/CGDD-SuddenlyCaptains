using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearController : MonoBehaviour {

    public Animator animator;
    public bool open;
	// Use this for initialization
	void Start () {
        open = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LandingGearDown()
    {
        animator.SetTrigger("openGear");
        animator.ResetTrigger("closeGear");
        open = true;
    }

    public void LandingGearUp()
    {
        animator.SetTrigger("closeGear");
        animator.ResetTrigger("openGear");
        open = false;
    }

    public bool isOpen()
    {
        return open;
    }
}
