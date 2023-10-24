using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    AnimationHandler animationHandler;
    Vector3 velocity;
    Vector3 direction;

  
   
    bool checkGround1;
    bool checkGround2;
    bool checkGround3;

    bool onGround;

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

    public PlayerControls playerControls;
    private InputAction move;
    private InputAction jump;
    public InputControlScheme ActiveControlScheme;
    private void Awake()
    {
        playerControls= new PlayerControls();
    }
    void Start()
    {
        animationHandler = GetComponent<AnimationHandler>();    
        
        Physics2D.queriesStartInColliders = false;
        rb2 = GetComponent<Rigidbody2D>();

        var collider = GetComponent<Collider2D>();

        groundCheckLength = collider.bounds.size.y + 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        CreatingRaycast();
        velocity += direction * movingSpeed * Time.deltaTime;
        rb2.velocity = new Vector2(velocity.x, rb2.velocity.y);
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        if(velocity.x > 0)
        {
            WalkingAnimationHandler();
        }
        if (direction.x == 0 || (direction.x < 0 == velocity.x > 0))
        {
            velocity.x *= 0;
        }
        if (!onGround)
        {
            DirectionOnAir();
        }
      
        //Movement();
    }


    private void OnEnable()
    {
        move = playerControls.Player.Move;
        jump = playerControls.Player.Jump;
        move.Enable();
        jump.Enable();
        //jump.performed += JumpingManagement;
    }
    private void OnDisable()
    {
        move.Disable();
        jump.Disable(); 
    }
    private void CreatingRaycast()
    {
        checkGround1 = Physics2D.Raycast(transform.position, new Vector2(1, -1), groundCheckLength);
        checkGround2 = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength);
        checkGround3 = Physics2D.Raycast(transform.position, new Vector2(-1, -1), groundCheckLength);

        Debug.DrawRay(transform.position, new Vector2(1, -1) * groundCheckLength, Color.green);
        Debug.DrawRay(transform.position, Vector2.down * groundCheckLength, Color.red);
        Debug.DrawRay(transform.position, new Vector2(-1, -1) * groundCheckLength, Color.blue);

        onGround = checkGround1 || checkGround2 || checkGround3;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        
       
        direction = context.ReadValue<Vector2>();

       

        Debug.Log(velocity.x);
   
    }

    private void WalkingAnimationHandler()
    {
        if (velocity.x > 0 || velocity.x < 0)
        {
            animationHandler.smalCharacterWalking = true;
        }
        if (direction.x == 0)
        {
            animationHandler.smalCharacterWalking = false;
        }

        

    }

    private void DirectionOnAir()
    {
        direction.x *= changeDirectionOnAir;
        
    }

    public void JumpingManagement(InputAction.CallbackContext context)
    {

        if(context.performed)
        { 
            if (onGround)
            {
                rb2.velocity = new Vector2(velocity.x, jumpPower);
            }
            if (rb2.velocity.y > 0)
            {
                rb2.velocity = new Vector2(rb2.velocity.x, rb2.velocity.y * jumpDown);
                Debug.Log("hoppar upp");
                animationHandler.isFalling = false;
                animationHandler.isJumping = true;

            }
        }

        if(rb2.velocity.y < 0)
        {
            animationHandler.isFalling = true;
            animationHandler.isFalling = false;
            Debug.Log("faller ner");
        }

        if(!onGround)
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
}
