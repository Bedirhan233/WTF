using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    AudioManager audioManager;
    AnimationHandler animationHandler;
    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        animationHandler = GetComponent<AnimationHandler>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            audioManager.PickUpStone();
            Destroy(other.gameObject);
            Throw.rock = 0;

        }
    }
}
