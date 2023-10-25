using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public Transform Target;
    Rigidbody2D rb2d;
    DistanceJoint2D joint2d;
    public int tetherDistance = 3;
    bool magnet;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        joint2d = GetComponent<DistanceJoint2D>();
    }

    void Magnet()
    {

        switch (magnet)
        {
            case true:
                while (distance.sqrMagnitude > 0)
                {
                    joint2d.enabled = true;
                    joint2d.distance = 0;

                }
                break;

            case false:
                joint2d.enabled = false;
                break;

        }
        magnet = !magnet;
    }
    void Update()
    {
        //if (Target - transform.position == joint2d.maxDistanceOnly)
        //{

        //}
        if (Input.GetKeyDown(KeyCode.M))
        {
            Magnet();
        }

    }

}
