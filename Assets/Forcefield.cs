using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{
    private DistanceJoint2D distancejoint;
    void Start()
    {
     distancejoint=GetComponent<DistanceJoint2D>();       
    }


    void Update()
    {

    }
}
