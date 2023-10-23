using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Vector3 velocity;
    Vector3 direction;

    bool onGround1;
    bool onGround2;
    bool onGround3;

    [Header ("Speed")]
    public float movingSpeed = 100;
    public float maxSpeed = 10;

    [Header("Jumping and Direction")]
    public float changeDirectionOnAir = 0.1f;
    public float jumpPower = 10;
    public float jumpDown = 0.1f;

    [Header("Jumping and Direction")]
    public float fallGravity = 4;
    public float jumpGravity = 1;

    float groundCheckLength;

    Rigidbody2D rb2;


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
        
        JumpingManagment();

    }


    private void Movement()
    {
        
            direction.x = Input.GetAxisRaw("Horizontal");

        if(!onGround1)
        {
            directionOnAir();
        }


        velocity += movingSpeed * direction * Time.deltaTime;

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);

        if (direction.x == 0 || (direction.x < 0 == velocity.x > 0))
        {
            velocity.x *= 0;
        }
        rb2.velocity = new Vector2(velocity.x, rb2.velocity.y);
    }

    private void directionOnAir()
    {
        direction.x = Input.GetAxisRaw("Horizontal") * changeDirectionOnAir;
    }

    private void JumpingManagment()
    {
        

        if (Input.GetButtonDown("Jump") && (onGround1 || onGround2 || onGround3))
        {
            rb2.velocity = new Vector2(velocity.x, jumpPower);
        }
        if (Input.GetButtonUp("Jump") && rb2.velocity.y > 0)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, rb2.velocity.y * jumpDown);
        }

        onGround1 = Physics2D.Raycast(transform.position, new Vector2(1,-1), groundCheckLength);
        onGround2 = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength);
        onGround3 = Physics2D.Raycast(transform.position, new Vector2(-1, -1), groundCheckLength);

        Debug.DrawRay(transform.position, new Vector2(1, -1) * groundCheckLength, Color.green);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckLength, Color.red);
        Debug.DrawRay(transform.position, new Vector2(-1, -1) * groundCheckLength, Color.blue);


        // gravity

        if (rb2.velocity.y < 0)
        {
            rb2.gravityScale = fallGravity;
        }
        if (rb2.velocity.y > 0)
        {
            rb2.gravityScale = jumpGravity;
        }

        
    }
}
