using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;

    public bool smalCharacterWalking;

    bool smalCharacter;
    bool bigCharacter;

    bool smalCharacterJumping;
    bool smalCharacterFalling;
    bool smalCharacterLanding;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "SmalGuy")
        {
        SmalCharacterWalkingAnimation();
        }

        if(gameObject.tag == "BigGuy")
        {
            BigCharacterWalkingAnimation();
        }
       
        
    }

    void SmalCharacterWalkingAnimation()
    {

        if(smalCharacterWalking) 
        { 
        animator.SetBool("IsWalking", true);
        }
        
        if (!smalCharacterWalking)
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void BigCharacterWalkingAnimation()
    {

        if (smalCharacterWalking)
        {
            animator.SetBool("IsWalking", true);
        }

        if (!smalCharacterWalking)
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
