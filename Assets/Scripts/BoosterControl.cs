using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterControl : MonoBehaviour {

    public AudioClip impact;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        
    }

    public void stopSound()
    {
        audioSource.Stop();
    }


}
