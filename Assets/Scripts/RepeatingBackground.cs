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
        Vector2 spaceOffset = new Vector2(0, -(verticalHeight * 2f));
        transform.position = (Vector2)transform.position + spaceOffset;
    }
}
