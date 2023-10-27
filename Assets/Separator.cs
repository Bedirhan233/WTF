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
    // Start is called before the first frame update
    void Start()
    {
        spriteRendererSeparator = GetComponent<SpriteRenderer>();
        Invoke("LookFor", 0.5f);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(separatorActivated==false)
        {
            distanceJoint.enabled = false;
            spriteRendererForce.enabled=false;
        }
        else if (separatorActivated==true) 
        {
            distanceJoint.enabled = true;
            spriteRendererForce.enabled = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (separatorActivated==true)
        {
            spriteRendererSeparator.color = new Color(0.2f, 0.7f, 0.3f);
        }
        else if(separatorActivated==false)
        {
            spriteRendererSeparator.color = new Color(0.7f, 0.4f, 0.2f);
        }
        separatorActivated =!separatorActivated;

    }
    void LookFor()
    {
       BigGuy = GameObject.FindGameObjectWithTag("BigGuy");
         distanceJoint= BigGuy.GetComponent<DistanceJoint2D>();
        spriteRendererForce = Forcefield.GetComponent<SpriteRenderer>();
    }
}
