using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    public SpriteRenderer bigCharacter;
    Rigidbody2D rigidbody2;
    public float speed;
    Vector2 direction;

    public static int totalRocks;

    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        totalRocks++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rigidbody2 == null)
        {
            return; 
        }   
        else
          rigidbody2.gravityScale = 2;

        if(collision.gameObject.tag == "Other")
        {
            audioManager.WallHittingGrass();
            
        }
        if(collision.gameObject.tag =="Play")
        {
            SceneManager.LoadScene(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Total rock in scene " + totalRocks);

        if (Throw.rock == 1)
        {
            if (CharacterMovement.lookingRight == false)
            {
                direction = Vector2.right;
            }
            else if (CharacterMovement.lookingRight == true)
            {
                direction = Vector2.left;
            }
            Throw.rock++;
            rigidbody2.velocity = direction * speed;
        }
    }


    //private void OnDestroy()
    //{
    //    Throw.rock--;
    //}
}
