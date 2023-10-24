using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction playerControls;
    Vector2 direction=Vector2.zero;
    Rigidbody2D rb2D;
    public int speed;
    private void Start()
    {
        rb2D=GetComponent<Rigidbody2D>();   
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Update()
    {

        direction = playerControls.ReadValue<Vector2>();
    }
   private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(direction.x*speed,direction.y*speed);
    }
}
