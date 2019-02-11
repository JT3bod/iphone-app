using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour {
    public AudioSource audioComponent;
    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip levelComplete;
    public AudioClip destruction;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void correctAudio()
    {
        audioComponent.clip = correct;
        audioComponent.Play();
    }
    public void incorrectAudio()
    {
        audioComponent.clip = incorrect;
        audioComponent.Play();
    }
    public void destructionAudio()
    {
        audioComponent.clip = destruction;
        audioComponent.Play();
    }
    public void levelCompleteAudio()
    {
        audioComponent.clip = levelComplete;
        audioComponent.Play();
    }
}
