using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separator : MonoBehaviour
{
    bool separatorActivated = false;
    DistanceJoint2D distanceJoint;
    public GameObject Forcefield;
    public GameObject BigGuy;
    public SpriteRenderer spriteRendererForce;
    SpriteRenderer spriteRendererSeparator;
    BoxCollider2D boxCollider2D;
    float timer;
    public float timeSeparated = 5;
    // Start is called before the first frame update
    void Start()
    {
        spriteRendererSeparator = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        Invoke(nameof(LookFor), 0.5f);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        timer = Time.time;
        if (separatorActivated == false)
        {
            distanceJoint.enabled = false;
            spriteRendererForce.enabled = false;
            boxCollider2D.enabled = false;
            spriteRendererSeparator.color = new Color(0.7f, 0.4f, 0.2f);
        }

    }


    
    private void Update()
       
    {
        if (distanceJoint != null)
        {

       
        if(Time.time-timer>timeSeparated && distanceJoint.enabled==false)
        {
           
            boxCollider2D.enabled = true;
            distanceJoint.enabled = true;
            spriteRendererForce.enabled = true;
            separatorActivated = false;
        }
        }
    }
    void LookFor()
    {
       BigGuy = GameObject.FindGameObjectWithTag("BigGuy");
         distanceJoint= BigGuy.GetComponent<DistanceJoint2D>();
        spriteRendererForce = Forcefield.GetComponent<SpriteRenderer>();
    }
}
