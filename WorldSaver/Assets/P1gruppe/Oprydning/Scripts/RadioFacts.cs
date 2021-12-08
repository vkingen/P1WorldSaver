using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioFacts : MonoBehaviour
{
    AudioSource radioFact;
    public AudioClip[] clips;
    public GameObject radioImage;


    private void Start()
    {
        radioFact = GetComponent<AudioSource>();
        
    }

    public void PlaySound()
    {
        radioFact.clip = clips[Random.Range(0, clips.Length)];
        radioFact.Play();
    }

    private void Update()
    {
        if(radioFact.isPlaying)
        {
            radioImage.SetActive(true);

        }
        else
        {

            radioImage.SetActive(false);

        }
    }

}
