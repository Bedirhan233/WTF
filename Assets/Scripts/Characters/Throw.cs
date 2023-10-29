using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Throw : MonoBehaviour
{
    public GameObject rockObject;
    public GameObject Throwspot;
    AudioManager audioManager;

    bool throwing = false;
    public float timer;

    public float animationLength = 5;
    public float timerThrow = 7;


    int totalRock;

    
    AnimationHandler animationHandler;
    public static int rock = 0;
    void Start()
    {
        rock = 0;
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        animationHandler = GetComponent<AnimationHandler>();
    }
    public void ThrowHappen()
    {
        
        if (rock == 0)
        {
            rock++;
            throwing = true;


        }

        
        



    }
    private void Update()
    {
         
        if(throwing) 
        {
            timer += Time.deltaTime;
            

            if(timer < animationLength)
            {
                animationHandler.isThrowing = true;
            }
            if (timer > timerThrow)
            {
                
                if(Rock.totalRocks < 1) 
                {
                Instantiate(rockObject, Throwspot.transform.position, Quaternion.identity);
                    audioManager.ThrowUpStone();
                }
               

                
            }
            if ( timer > animationLength)
            {
                throwing = false;
                animationHandler.isThrowing = false;
                timer = 0;
                Rock.totalRocks = 0;

            }

            

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock") && Time.time-Rock.timePassed > 1)
        {
            audioManager.PickUpStone();
            Destroy(other.gameObject);
            Throw.rock = 0;

        }
    }

}
