using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour {

    private AudioSource audioSource;

    private float musicVolume = 0.5f;
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
    public float getAudioVolume()
    {
        return musicVolume;
    }
}
