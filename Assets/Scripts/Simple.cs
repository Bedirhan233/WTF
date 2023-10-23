using UnityEngine;


public class Simple : MonoBehaviour
{

    Vector3 velocity;
    Vector2 direction;

    Vector2 position;

    Rigidbody2D rb;

    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");


        velocity = speed * direction * Time.deltaTime;

        position = velocity;

        rb.velocity = velocity;

       

    }
}