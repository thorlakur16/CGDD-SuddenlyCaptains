using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterControl : MonoBehaviour {

    public AudioClip impact;
    AudioSource audioSource;
    public Volume volume;

    // Use this for initialization
    void Start () {
        volume = GameObject.FindObjectOfType<ShipHandler>().GetComponent<Volume>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = volume.getAudioVolume()*0.5f;
            audioSource.Play();
        }
        
    }

    public void stopSound()
    {
        audioSource.Stop();
    }


}
