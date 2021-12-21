using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFacts : MonoBehaviour
{
    AudioSource radioFact; // this Audio Source
    public AudioClip[] clips; // reference to a predefined audio clips array
    public GameObject radioImage; // reference to the radio image


    private void Start()
    {
        radioFact = GetComponent<AudioSource>();
        
    }

    public void PlaySound()
    {
        radioFact.clip = clips[Random.Range(0, clips.Length)]; // Assigning the Audio Source's clip to a random one of the Clips[] array
        radioFact.Play(); // Play the Audio Source with the chosen clip
    }

    private void Update()
    {
        if(radioFact.isPlaying) // if the Audio Source is playing then set the referenced image to true or else set it to false 
        {
            radioImage.SetActive(true);
        }
        else
        {
            radioImage.SetActive(false);
        }
    }

}
