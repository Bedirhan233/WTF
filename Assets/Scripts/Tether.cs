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
    public GameObject Forcefield;
    public SpriteRenderer ForcefieldSprite;
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
        distance=Target.position - transform.position;
        Forcefield.transform.position =transform.position + distance/2;
        
        
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
            Magnet();
        }

    }

}
