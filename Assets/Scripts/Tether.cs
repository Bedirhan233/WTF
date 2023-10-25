using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tether : MonoBehaviour
{
    GameObject Target;
    Rigidbody2D targetRb2d;
    Rigidbody2D rb2d;
    DistanceJoint2D joint2d;
    public int tetherDistance = 3;
    bool magnet;
    Vector3 distance;
    public GameObject Forcefield;
    SpriteRenderer ForcefieldSprite;
    // Start is called before the first frame update
    void Start()
    {
        
        Target = GameObject.FindGameObjectWithTag("SmalGuy");
        
        targetRb2d=Target.GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();
        joint2d = GetComponent<DistanceJoint2D>();
        joint2d.connectedBody = targetRb2d;
        Forcefield = GameObject.FindGameObjectWithTag("Forcefield");
        
        //Instantiate(Forcefield, Forcefield.transform.position,Quaternion.identity );
        ForcefieldSprite=Forcefield.GetComponent<SpriteRenderer>();
        //ForcefieldSprite.enabled = false;
    }

    //void Magnet()
    //{

    //    switch (magnet)
    //    {
    //        case true:
    //            while (distance.sqrMagnitude > 0)
    //            {
    //                joint2d.enabled = true;
    //                joint2d.distance = 0;

    //            }
    //            break;

    //        case false:
    //            joint2d.enabled = false;
    //            break;

    //    }
    //    magnet = !magnet;
    //}
    void Update()
    {
        distance=Target.transform.position - transform.position;
        Forcefield.transform.position =transform.position + distance/2;
        Debug.Log(distance);
        
        if (distance.sqrMagnitude >= joint2d.distance*joint2d.distance-0.5f)
        {
            ForcefieldSprite.color = new Color(0.23529411764705882f, 0.788235294117647f, 0.8196078431372549f, 0.5411765f);
            
          //  -Forcefield.transform.right = transform.position;
        }
        else
        {
            ForcefieldSprite.color = new Color(0.23529411764705882f, 0.788235294117647f, 0.8196078431372549f,0.3f);
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            //Magnet();
        }

    }

}
