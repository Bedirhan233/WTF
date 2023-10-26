using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject Rock;
    public GameObject Throwspot;
    AudioManager audioManager;

    int throwingCount = 0;


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
            Instantiate(Rock, Throwspot.transform.position, Quaternion.identity);
            rock++;
            if(throwingCount == 0) 
            {
                animationHandler.isThrowing = true;

            }
            throwingCount++;

        }
        



    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            Debug.Log("PickUp");
        audioManager.PickUpStone();
        Destroy(other.gameObject);
        rock=0;
        }   
    }
}
