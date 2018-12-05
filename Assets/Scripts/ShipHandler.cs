using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHandler : MonoBehaviour {

    public GameObject boosterRight;
    public GameObject boosterLeft;
    public GameObject mainThruster;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -Time.deltaTime, 0);
	}
}
