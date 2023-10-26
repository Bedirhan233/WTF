using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioSource source2;

    public AudioClip smalJumping, bigJumping, smalWalking, stoneHitWall, bigThrowing, pickUp, backgroundMusic, wallHitingGrass;

    public float jumpingSound = 1;
    public float backgroundMUsicVolume = 1;



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
        source2.volume = backgroundMUsicVolume;
    }



    public void SmalGuyJumpingSound()
    {
        source.clip = smalJumping;
        source.pitch = 1f;
        source.volume = jumpingSound;
        source.Play();

    }

    public void BigGuyJumpingSound()
    {
        source.clip = bigJumping;
        source.pitch = 0.5f;
        source.volume = jumpingSound;
        source.Play();

    }

    

    public void PickUpStone()
    {

        source.clip = pickUp;
        source.pitch = 1;
        source.PlayOneShot(pickUp);
    }

    public void ThrowUpStone()
    {

        source.clip = bigThrowing;
        source.pitch = 1;
        source.PlayOneShot(bigThrowing);
    }

    public void BackgroundMusic()
    {
        source2.Play(); 
    }

    public void WallHittingGrass()
    {
        source.clip = wallHitingGrass;
        source.pitch = 1;
        source.PlayOneShot(wallHitingGrass); ;
    }

    public void StoneHittingWall()
    {
        source.clip = stoneHitWall;
        source.pitch = 1;
        source.PlayOneShot(stoneHitWall); ;
    }
}
