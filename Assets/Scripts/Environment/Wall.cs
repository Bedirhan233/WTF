using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Grass")
        {
            audioManager.WallHittingGrass();
        }
        if (collision.gameObject.tag == "Rock")
        {
            audioManager.StoneHittingWall();
        }
    }
}
