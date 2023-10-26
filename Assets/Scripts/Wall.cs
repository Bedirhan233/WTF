using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        if(audioManager == null) 
        {
        audioManager = GameObject.FindAnyObjectByType<AudioManager>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Grass")
        {
            audioManager.WallHitingGround();
        }

        if (other.gameObject.tag == "Wall")
        {
            audioManager.RockHittingWall();
        }
    }
}
