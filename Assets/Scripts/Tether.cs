using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public Transform Target;
    Rigidbody2D rb2d;
    DistanceJoint2D joint2d;
    public int tetherDistance=3;
    // Start is called before the first frame update
    void Start()
    {
       rb2d= GetComponent<Rigidbody2D>();
        joint2d = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = transform.position - Target.position;
        Debug.Log(distance.sqrMagnitude);
        if (distance.sqrMagnitude>tetherDistance*tetherDistance)
        {
            joint2d.enabled=true; 
           
           

        }
        else 
            joint2d.enabled = false;
    }
    
}
