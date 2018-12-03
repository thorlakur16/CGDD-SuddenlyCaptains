using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster_control : MonoBehaviour {

    public bool boosterOn = false;

    public Animator animator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startBooster()
    {
        Debug.Log("boosterOn in booster");
        boosterOn = true;
        if(animator.GetBool("active") != true)
        {
            animator.SetBool("active", true);
        }
        
    }
    public void shutdownBooster()
    {
        Debug.Log("boosterOff in booster");
        boosterOn = false;
        animator.SetBool("active", false);
    }
}
