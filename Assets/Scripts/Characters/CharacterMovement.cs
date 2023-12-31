using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    AnimationHandler animationHandler;
    AudioManager audioManager;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb2;

    Vector3 velocity;
    Vector3 direction;

    bool checkGround1;
    bool checkGround2;
    bool checkGround3;

    bool onGround;

    public static bool lookingRight;

    [Header("Speed")]
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



    public PlayerControls playerControls;
   
    GameObject StartPosition;
    private void Awake()
    {

        playerControls = new PlayerControls();
        StartPosition = GameObject.FindGameObjectWithTag("Start");
    }
    void Start()
    {

        animationHandler = GetComponent<AnimationHandler>();
        transform.position = StartPosition.transform.position;
        Physics2D.queriesStartInColliders = false;
        rb2 = GetComponent<Rigidbody2D>();

        var collider = GetComponent<Collider2D>();

        groundCheckLength = collider.bounds.size.y + 0.1f;

        spriteRenderer = GetComponent<SpriteRenderer>();

        audioManager = FindAnyObjectByType<AudioManager>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        CreatingRaycast();
        MovingWithScript();

        AnimationHandler();



        //Movement();
    }

    private void MovingWithScript()
    {
        velocity += movingSpeed* Time.deltaTime*direction;
        rb2.velocity = new Vector2(velocity.x, rb2.velocity.y);
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);

        if (direction.x == 0 || (direction.x < 0 == velocity.x > 0))
        {
            velocity.x *= 0;
        }
        if (!onGround)
        {
            DirectionOnAir();
        }
        if (onGround)
        {
            velocity += movingSpeed * Time.deltaTime * direction;
        }
    }

  
    

    private void CreatingRaycast()
    {
        Vector3 start = transform.position;
        Vector3 left = transform.position;
        Vector3 right = transform.position;

        start.x -= 0f;
        left.x -= -0.3f;
        right.x -= 0.3f;

        checkGround1 = Physics2D.Raycast(start, Vector2.down, groundCheckLength);
        checkGround2 = Physics2D.Raycast(left, Vector2.down, groundCheckLength);
        checkGround3 = Physics2D.Raycast(right, Vector2.down, groundCheckLength);

        Debug.DrawRay(start, Vector2.down * groundCheckLength, Color.green);
        Debug.DrawRay(left, Vector2.down * groundCheckLength, Color.red);
        Debug.DrawRay(right, Vector2.down * groundCheckLength, Color.blue);

        onGround = checkGround1 || checkGround2 || checkGround3;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();


    }

    private void AnimationHandler()
    {

        // g�r �t v�nster
        if (velocity.x > 0)
        {
            animationHandler.smallCharacterWalking = true;
            animationHandler.bigCharacterWalking = true;
            spriteRenderer.flipX = false;
            lookingRight = false;

        }

        //g�r �t h�ger

        if (velocity.x < 0)
        {
            animationHandler.smallCharacterWalking = true;
            animationHandler.bigCharacterWalking = true;
            spriteRenderer.flipX = true;
            lookingRight = true;


        }

        // st�r still
        if (direction.x == 0)
        {
            animationHandler.smallCharacterWalking = false;
            animationHandler.bigCharacterWalking = false;
        }

        // hoppar upp

        if (rb2.velocity.y > 0)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, rb2.velocity.y * jumpDown);
            animationHandler.isFalling = false;
            animationHandler.isJumping = true;
        }

        // faller ner

        if (rb2.velocity.y < 0)
        {
            animationHandler.isFalling = true;
            animationHandler.isJumping = false;
        }

        // p� marken
        if (onGround)
        {
            animationHandler.isFalling = false;
            animationHandler.isJumping = false;
        }
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

    private void DirectionOnAir()
    {
        direction.x *= changeDirectionOnAir;

    }

    public void JumpingManagement(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            if (onGround)
            {
                rb2.velocity = new Vector2(velocity.x, jumpPower);
            }



            if (gameObject.CompareTag("SmallGuy") && onGround)
            {
                audioManager.SmallGuyJumpingSound();

            }

            if (gameObject.CompareTag("BigGuy") && onGround)
            {
                audioManager.BigGuyJumpingSound();

            }




        }
    }
}
