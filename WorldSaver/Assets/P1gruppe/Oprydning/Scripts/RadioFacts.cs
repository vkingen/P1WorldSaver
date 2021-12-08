using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFacts : MonoBehaviour
{
    AudioSource radioFact;
    public AudioClip[] clips;

    private void Start()
    {
        radioFact = GetComponent<AudioSource>();
        
    }

    public void PlaySound()
    {
        radioFact.clip = clips[Random.Range(0, clips.Length)];
        radioFact.Play();
    }


}
