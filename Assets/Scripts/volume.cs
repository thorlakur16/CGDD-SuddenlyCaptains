using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volume : MonoBehaviour {

    private AudioSource audioSource;

    private float musicVolume = 1f;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        audioSource.volume = musicVolume;
	}

    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}
