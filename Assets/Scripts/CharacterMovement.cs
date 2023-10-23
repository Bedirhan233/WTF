using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Vector3 velocity;
    Vector3 direction;

    float maxSpeed = 10;

    Rigidbody2D rb2;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");

        velocity += speed * direction * Time.deltaTime;

        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);

        if(direction.x == 0 || (direction.x < 0 == velocity.x > 0))
        {
            velocity.x *= 0;
        }
        Debug.Log(direction.x);

        rb2.velocity = new Vector2(velocity.x, rb2.velocity.y);
        
    }
}
