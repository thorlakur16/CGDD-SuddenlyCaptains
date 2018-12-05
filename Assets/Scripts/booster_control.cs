using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster_control : MonoBehaviour {

    public bool boosterOn = false;
    private GameObject theShip;

    public Animator animator;

    // Use this for initialization
    void Start () {
        theShip = GameObject.Find("Ship");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /*public void startBoosterLeft()
    {
        boosterOn = true;
        theShip.transform.Translate(-Time.deltaTime, 0, 0); //move ship
        if (animator.GetBool("active") != true)
        {
            animator.SetBool("active", true);
        }
        
    }
    public void startBoosterRight()
    {
        boosterOn = true;
        theShip.transform.Translate(Time.deltaTime,0 , 0); //move ship
        if (animator.GetBool("active") != true)
        {
            animator.SetBool("active", true);
        }

    }
    public void startBoosterUp()
    {
        boosterOn = true;
        theShip.transform.Translate(0, Time.deltaTime, 0); //move ship
        if (animator.GetBool("active") != true)
        {
            animator.SetBool("active", true);
        }

    }*/
    public void startBooster(float x, float z, float y)
    {
        boosterOn = true;
        theShip.transform.Translate(x,y,z); //move ship
        if (animator.GetBool("active") != true)
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
