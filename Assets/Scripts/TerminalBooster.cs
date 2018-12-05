using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalBooster : MonoBehaviour {

    private booster_control theBooster;

    // Use this for initialization
    void Start () {
		theBooster = FindObjectOfType<booster_control>();
        foreach (booster_control booster in GameObject.FindObjectsOfType(typeof(booster_control)))
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
