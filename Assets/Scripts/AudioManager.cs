using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioSource source2;
    public AudioClip smalJumping, bigJumping, smalWalking, bigWalking, bigThrowing, pickUp;

    public float jumpingSoundVolume = 0.5f;
    public float backgroundMusicVolume = 1f;



    bool playingSmalJump;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        playingSmalJump = false;
        source2.volume = backgroundMusicVolume;

    }



    public void SmalGuyJumpingSound()
    {
        source.clip = smalJumping;
        source.pitch = 1f;
        source.volume = jumpingSoundVolume;
        source.Play();

    }

    public void BigGuyJumpingSound()
    {
        source.clip = bigJumping;
        source.pitch = 0.5f;
        source.volume = jumpingSoundVolume;
        source.Play();

    }

    public void PickUpStone()
    {

        source.clip = pickUp;
        source.pitch = 1;
        source.PlayOneShot(pickUp);
    }

    public void ThnrowStone()
    {

        source.clip = bigThrowing;
        source.pitch = 1;
        source.PlayOneShot(bigThrowing);
    }

    public void BackgroundMusic()
    {
        source2.Play();
        
    }
}
