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
    public GameObject PortalVisual;
    SpriteRenderer ForcefieldSprite;
    // Start is called before the first frame update
    void Start()
    {

        Target = GameObject.FindGameObjectWithTag("SmalGuy");

        targetRb2d = Target.GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();
        joint2d = GetComponent<DistanceJoint2D>();
        joint2d.connectedBody = targetRb2d;
        Forcefield = GameObject.FindGameObjectWithTag("Forcefield");

        //Instantiate(Forcefield, Forcefield.transform.position,Quaternion.identity );
        ForcefieldSprite = Forcefield.GetComponent<SpriteRenderer>();
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
        distance = Target.transform.position - transform.position;
        Forcefield.transform.position = transform.position + distance / 2;
        //Debug.Log(distance);

        if (distance.sqrMagnitude >= joint2d.distance * joint2d.distance - 0.5f)
        {
            ForcefieldSprite.color = new Color(255, 255, 255, 150);

            //  -Forcefield.transform.right = transform.position;
        }
        else
        {
            ForcefieldSprite.color = new Color(255, 255, 255, 255);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            //Magnet(); 
        }

    }
    public void ChangePlace(Transform small)
    {
        Target.transform.position = transform.position;
        transform.position = small.position+new Vector3(0.05f, 1.2f, 0);
        Instantiate(PortalVisual, transform.position, Quaternion.identity);
        Instantiate(PortalVisual, Target.transform.position, Quaternion.identity);
    }
}
