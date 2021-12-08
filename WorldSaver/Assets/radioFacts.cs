using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioFacts : MonoBehaviour
{

    public AudioSource radioFact;
    public AudioClip[] clips;


    private void Start()
    {
        radioFact = GetComponent<AudioSource>();

    }

    public void PlayRadioSound()
    {
        radioFact.clip = clips[Random.Range(0, clips.Length)];
        radioFact.Play();
    }


}
