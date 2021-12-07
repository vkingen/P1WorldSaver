using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFacts : MonoBehaviour
{
    AudioSource aS;
    public AudioClip[] clips;

    private void Start()
    {
        aS = GetComponent<AudioSource>();
        
    }



    public void PlaySound()
    {
        aS.clip = clips[Random.Range(0, clips.Length)];
        aS.Play();
    }


}
