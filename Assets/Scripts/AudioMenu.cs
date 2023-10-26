using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;

    public AudioClip clickingSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundMusic();
    }

    void BackgroundMusic()
    {
        audioSource2.Play();
    }

    public void ClickingSound()
    {
        audioSource.clip = clickingSound;
        audioSource2.Play();
    }
}
