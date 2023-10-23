using UnityEngine;

//This script is a clean powerful solution to a top-down movement player
public class Simple : MonoBehaviour
{

    public float maxSpeed = 5; //Our max speed
    public float acceleration = 20; //How fast we accelerate
    public float deacceleration = 4; //brake power

    //Private variables for internal logic
    Vector2 rawInput; //raw input values from the player
    Vector2 velocity; //Our current velocity
    Vector2 position; //our position

    Rigidbody2D rb2D; //Ref to our rigidbody

    private void Start()
    {
        //assign our ref.
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Get the raw input
        rawInput.x = Input.GetAxisRaw("Horizontal");
        rawInput.y = Input.GetAxisRaw("Vertical");

        //If we have a square magnitude over one, normalize the length of the vector to 1
        //if it's shorter then one we don't need this step.
        if (rawInput.sqrMagnitude > 1)
        {
            rawInput.Normalize();
        }

        //add our input to our velocity
        //This provides accelleration +10m/s/s
        velocity += rawInput * acceleration * Time.deltaTime;

        //Check our max speed, if our magnitude is faster them max speed
        if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            //Normalize our velocity and change the magnitude to our max speed.
            velocity.Normalize();
            velocity *= maxSpeed;
        }

     

        //Update our position vector with our movement over time
        position += velocity * Time.deltaTime;

        //Move our transform based to our updated position.
        //transform.position = position;

        //Now we can move with the rigidbody and we get propper collisions
        rb2D.velocity = velocity;
    }
}