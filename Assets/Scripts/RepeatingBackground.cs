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
        float thisX = transform.position.x;
        float shipX = theShip.transform.position.x;
        float distance;
        if (thisX > shipX)
        {
            distance = thisX - shipX;
        }
        else
        {
            distance = shipX - thisX;
        }

        Vector2 spaceOffset = new Vector2(0f, 0f);
        
        if(thisX < shipX)
        {
            spaceOffset = new Vector2((thisX + distance), -(verticalHeight * 2f));
        }
        else
        {
            spaceOffset = new Vector2((thisX - distance), -(verticalHeight * 2f));
        }
        transform.position = (Vector2)transform.position + spaceOffset;
    }
}
