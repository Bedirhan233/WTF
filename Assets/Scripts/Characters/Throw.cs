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

    bool itNowExists=false;

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
            
            throwing = true;


        }



        animationHandler.isThrowing = true;


        

        if (rock < 1)
        {
            Instantiate(rockObject, Throwspot.transform.position, Quaternion.identity);
            itNowExists = true;
            audioManager.ThrowUpStone();
            rock++;

        }




        if (itNowExists)
        {
            throwing = false;
            animationHandler.isThrowing = false;
            timer = 0;
            
            Rock.totalRocks = 0;

        }

    }

    







    private void Update()
    {

        if (throwing)
        {
            timer += Time.deltaTime;

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock") && Time.time-Rock.timePassed > 1)
        {
            audioManager.PickUpStone();
            Destroy(other.gameObject);
            Throw.rock = 0;
            itNowExists = false;    

        }
    }

}
