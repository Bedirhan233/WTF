

using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Jump,
    Fall,
    Dead,
    Attack,

}
public enum ParallelPlayerState
{
    Crouch,
    Idle,

}
//This script is a clean powerful solution to a top-down movement player
public class Movement : MonoBehaviour
{
    //Public variables that wer can edit in the editor
    public float maxSpeed = 5; //Our max speed
    public float acceleration = 20; //How fast we accelerate
    public float deacceleration = 4; //brake power


    public float jumpPower = 8;
    public float groundCheckDistance = 0.1f;
    bool onGround = true;
    public float velocityX;
    float groundCheckLength;
    int maxJumps = 1;
    int currentJumps = 0;
    int up=1;
    bool onRoof = false;
   

    Rigidbody2D rb2D; //Ref to our rigidbody
    public ParallelPlayerState parallellstate = ParallelPlayerState.Idle;
    public PlayerState state = PlayerState.Idle;
    private void Start()
    {
        //assign our ref.
       
        Physics2D.queriesStartInColliders = false;
        rb2D = GetComponent<Rigidbody2D>();
        var collider = GetComponent<Collider2D>();
        groundCheckLength = collider.bounds.size.y + groundCheckDistance;
    }

    void Update()
    {


        MovementX();



        RaycastHit2D hit;
        //onRoof = Physics2D.Raycast(transform.position, Vector2.up, 1);
        hit = Physics2D.Raycast(transform.position, new Vector2(0,up), 30);
        
        if (hit.collider != null)
            onRoof = true;
        else
            onRoof = false;
        
        Debug.Log(onRoof + " " + hit.collider);
        

        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps)
        {

            currentJumps++;
            rb2D.velocity = new Vector2(rb2D.velocity.x, up*jumpPower);
            state = PlayerState.Jump;
            onGround = false;
            return;
        }
        onGround = Physics2D.Raycast(transform.position, new Vector2(0,-up), 0.6f);
        if (onGround)
        {
            currentJumps = 0;
        }
        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * up * 0.25f);
        }


        

        if (Input.GetKey(KeyCode.S))
        {
            parallellstate = ParallelPlayerState.Crouch;
            
            if (onGround)
            {
                rb2D.velocity = Vector2.zero;
            }
            //else rb2D.gravityScale = 0.000001f;

        }
        else
            parallellstate = ParallelPlayerState.Idle;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            up = -up;
            transform.position = hit.point;
            transform.Rotate(new Vector3(180f, 0));
            rb2D.gravityScale= - rb2D.gravityScale;
           


        }
        

            
    }

    public void MovementX()
    {
        ;

        //Get the raw input
        float x = Input.GetAxisRaw("Horizontal");

            


        //add our input to our velocity
        //This provides accelleration +10m/s/s
        velocityX += x * acceleration * Time.deltaTime;

        //Check our max speed, if our magnitude is faster them max speed
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);
        //If we have zero input from the player
        if (x == 0 || (x < 0 == velocityX > 0))
        {
            //Reduce our speed based on how fast we are going
            //A value of 0.9 would remove 10% or our speed
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }
        if (x == 0 && onGround && rb2D.velocity.y == 0)
        {
            state = PlayerState.Idle;
        }
        else if (onGround && velocityX > 0 && rb2D.velocity.y == 0)
        {
            state = PlayerState.Walk;
        }

        //Move our transform based to our updated position.
        //transform.position = position;

        //Now we can move with the rigidbody and we get propper collisions
        rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);

    }
}