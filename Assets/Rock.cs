using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public SpriteRenderer bigCharacter;
    Rigidbody2D rigidbody2;
    public float speed;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        if(bigCharacter.flipX ==false)
        {
            direction = Vector2.right;
        }
        else
            direction = Vector2.left;
        

        rigidbody2.velocity = direction*speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rigidbody2 == null)
        {
            return; 
        }   
        else
          rigidbody2.gravityScale = 2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnDestroy()
    //{
    //    Throw.rock--;
    //}
}
