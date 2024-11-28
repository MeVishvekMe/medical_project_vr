using System;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour {
    public AudioClip[] audioClips = new AudioClip[4];
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SetClip1();
    }

    public void SetClip1() {
        audioSource.PlayOneShot(audioClips[0]);
    }
    
    public void SetClip2() {
        audioSource.PlayOneShot(audioClips[1]);
    }
    
    public void SetClip3() {
        audioSource.PlayOneShot(audioClips[2]);
    }
    
    public void SetClip4() {
        audioSource.PlayOneShot(audioClips[3]);
    }
}
