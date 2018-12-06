using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalBooster : MonoBehaviour {

    private BoosterControl theBooster;

    // Use this for initialization
    void Start () {
		theBooster = FindObjectOfType<BoosterControl>();
        foreach (BoosterControl booster in GameObject.FindObjectsOfType(typeof(BoosterControl)))
        {
            if (booster.name == "TerminalUp")
            {
                theBooster = booster;
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
