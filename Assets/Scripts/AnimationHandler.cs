using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;

    public bool smalCharacterWalking;
    public bool isJumping;
    public bool isFalling;

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
       
        SmalCharacterWalkingAnimation();
        SmalCharacterIsJumping();
        SmalCharacterFalling();


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

    void SmalCharacterIsJumping()
    {
        if(isJumping) 
        {
        animator.SetBool("isJumping", true);
        }

        if (!isJumping)
        {
            animator.SetBool("isJumping", false);
        }
    }

    void SmalCharacterFalling()
    {
        if(isFalling) 
        {
            animator.SetBool("isFalling", true);
        }
        if (!isFalling)
        {
            animator.SetBool("isFalling", false);
        }
    }
}
