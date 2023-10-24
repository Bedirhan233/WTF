using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    Animator animator;

    public bool smalCharacterWalking;

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
        
    }

    void SmalCharacterWalkingAnimation()
    {

        Debug.Log("DET FUNKAR");

        if(smalCharacterWalking) 
        { 
        animator.SetBool("IsWalking", true);
        }
        
        if (!smalCharacterWalking)
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
