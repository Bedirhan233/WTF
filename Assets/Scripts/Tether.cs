using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public Transform Target;
    Rigidbody2D rb2d;
    RelativeJoint2D joint2d;
    // Start is called before the first frame update
    void Start()
    {
       rb2d= GetComponent<Rigidbody2D>();
        joint2d = GetComponent<RelativeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = transform.position - Target.position;
        Debug.Log(distance.sqrMagnitude);
        if (distance.sqrMagnitude>25)
        {
            joint2d.enabled=true; 
            distance.Normalize();
            joint2d.linearOffset =distance*5 ;
           

        }
        else 
            joint2d.enabled = false;
    }
    
}
