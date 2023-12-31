using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    public SpriteRenderer bigCharacter;
    Rigidbody2D rigidbody2;
    public float speed;
    public float accelaration = 0.5f;
    Vector2 direction;
    float timer;
    float starttimer;
    public static int totalRocks;
    public static float timePassed;
    public float timeBeforeSpeed = 1;

    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        totalRocks++;
        timePassed = Time.time;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rigidbody2 == null || collision.gameObject.CompareTag("BigGuy"))
        {
            return; 
        }   
        else
          rigidbody2.gravityScale = 2;

        if(collision.gameObject.CompareTag("Other"))
        {
            audioManager.WallHittingGrass();
            
        }
        if(collision.gameObject.CompareTag("Play"))
        {
            SceneManager.LoadScene(1);
            Throw.rock = 0;
        }
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        

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
            if (timer < timeBeforeSpeed)
            {
                rigidbody2.velocity = direction * accelaration;

;
            }

            else if (timer > timeBeforeSpeed)
            {
            rigidbody2.velocity = direction * speed;
                
                Throw.rock++;
            }
            
        }
        
    }


    //private void OnDestroy()
    //{
    //    Throw.rock--;
    //}
}
