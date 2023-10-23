using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Vector3 velocity;
    Vector3 direction;

    bool onGround;
    float maxSpeed = 10;

    public float jumpPower = 6;   

    float groundCheckLength;

    Rigidbody2D rb2;

    public float speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rb2 = GetComponent<Rigidbody2D>();

        var collider = GetComponent<Collider2D>();

        groundCheckLength = collider.bounds.size.y + 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        

        Debug.DrawRay(transform.position, Vector2.down * groundCheckLength, Color.red);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb2.velocity = new Vector2(velocity.x, jumpPower);
        }
        if(Input.GetButtonUp("Jump") && onGround)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, rb2.velocity.y * 0.25f);
        }

        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength);

        if(rb2.velocity.y < 0)
        {
            rb2.gravityScale = 4;
        }
        if(rb2.velocity.y > 0)
        {
            rb2.gravityScale = 1;

        }

        Debug.Log(onGround);

    }

    private void Movement()
    {
        direction.x = Input.GetAxisRaw("Horizontal");

        velocity += speed * direction * Time.deltaTime;

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);

        if (direction.x == 0 || (direction.x < 0 == velocity.x > 0))
        {
            velocity.x *= 0;
        }
        rb2.velocity = new Vector2(velocity.x, rb2.velocity.y);
    }
}
