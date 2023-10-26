using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    AudioSource source;
    public AudioClip smalJumping, bigJumping, smalWalking, bigWalking, bigThrowing;



    bool playingSmalJump;
    // Start is called before the first frame update
    void Start()
    {
       source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playingSmalJump = false;
    }

    public void SmalGuyJumpingSound()
    {
        source.clip = smalJumping;
        source.pitch = 1f;
        source.Play();

    }

    public void BigGuyJumpingSound()
    {
        source.clip = bigJumping;
        source.pitch = 0.5f;
        source.Play();

    }

    public void BigGuyWalkingSound()
    {
        source.clip = bigWalking;
        source.pitch = 1;
        source.PlayOneShot(bigWalking);

    }
}
