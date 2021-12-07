using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalSound : MonoBehaviour

{
    public AudioSource sharkInPain;
    public AudioSource completed;


    private void Start()
    {

        sharkInPain = gameObject.AddComponent<AudioSource>();
        completed = gameObject.AddComponent<AudioSource>();
    }

}
