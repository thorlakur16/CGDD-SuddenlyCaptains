using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private float verticalHeight;

    public ShipHandler theShip;
	// Use this for initialization
	void Start () {
        verticalHeight = 40f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.y > theShip.transform.position.y+ verticalHeight / 1.5f)
        {
            RepositionBackground();
        }
	}

    private void RepositionBackground()
    {        
        transform.position = new Vector2(theShip.transform.position.x, transform.position.y -verticalHeight * 2f);
    }
}
