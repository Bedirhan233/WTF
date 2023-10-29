using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;
    

    public bool smallCharacterWalking;
    public bool isJumping;
    public bool isFalling;
    //public bool isWalking;
    bool smallCharacter;
    bool bigCharacter;

    public bool bigCharacterWalking;
    public bool bigCharacterJumping;

    public bool isThrowing;

    
    bool smallCharacterFalling;
    bool smallCharacterLanding;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("SmallGuy"))
        {
        SmallCharacterWalkingAnimation();
            SmallCharacterIsJumping();
            SmallCharacterFalling();
        }

        if(gameObject.CompareTag("BigGuy"))
        {
            BigCharacterWalkingAnimation();
            ThrowingAnimation();
            BigCharacterWalking();
            BigCharacterJumpingAnimation();
        }


        
        

    }

    void SmallCharacterWalkingAnimation()
    {

        if(smallCharacterWalking) 
        { 
        animator.SetBool("IsWalking", true);
        }
        
        if (!smallCharacterWalking)
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void BigCharacterWalkingAnimation()
    {

        if (smallCharacterWalking)
        {
            animator.SetBool("BigGuyWalking", true);
        }

        if (!smallCharacterWalking)
        {
            animator.SetBool("BigGuyWalking", false);
        }

    }

    

    void SmallCharacterIsJumping()
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

    void SmallCharacterFalling()
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

    void BigCharacterWalking()
    {
        if(bigCharacterWalking)
        {
            animator.SetBool("BigGuyWalking", true);
        }

        if(!bigCharacterWalking)
        {
            animator.SetBool("BigGuyWalking", false);
        }
    }
    void BigCharacterJumpingAnimation()
    {
        if(isJumping)
        {
        animator.SetBool("bigGuyJump", true);
        }

        if (!isJumping)
        {
            animator.SetBool("bigGuyJump", false);
        }
    }

    void ThrowingAnimation()
    {
       
        if(isThrowing)
        {
            animator.SetBool("isThrowing", true);
            

        }
        if (!isThrowing)
        {
            animator.SetBool("isThrowing", false);

        }



    }
}
