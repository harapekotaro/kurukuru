using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    private AudioSource audioSource;

    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    public void Playhit()
    {
        audioSource.clip = audioClip1;
        audioSource.Play();
    }
    public void Playover()
    {
        
    }

    public void PlayBane()
    {
        audioSource.clip = audioClip3;
        audioSource.Play();
    }
}