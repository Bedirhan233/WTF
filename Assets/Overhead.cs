using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overhead : MonoBehaviour
{
    GameObject Target;
    public bool onSmall;
    Vector3 compensationVector;
    SpriteRenderer spriteRenderer;
    void Start()
    {
       // spriteRenderer=GetComponent<SpriteRenderer>();
        if(onSmall)
        {
        Target = GameObject.FindGameObjectWithTag("SmallGuy");
            compensationVector = new Vector3(-0.11f, -0.6f, 0);
            //spriteRenderer.color = new Color(1, 0, 0);
        }
        else
        { 
        Target= GameObject.FindGameObjectWithTag("BigGuy");
        compensationVector = new Vector3(-0.11f, -1f, 0);
        //spriteRenderer.color = new Color(0, 0.8f, 0.9f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        transform.position = Target.transform.position - compensationVector;
    }
}
