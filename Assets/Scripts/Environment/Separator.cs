using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separator : MonoBehaviour
{
    bool separatorActivated = false;
    DistanceJoint2D distanceJoint;
    public GameObject Forcefield;
    GameObject BigGuy;
    SpriteRenderer spriteRendererForce;
    SpriteRenderer spriteRendererSeparator;
    BoxCollider2D boxCollider2D;
    public Sprite SpriteOn;
    public Sprite SpriteOff;
    float timer;
    public float timeSeparated = 25;
    [Header("Cameras")]
    public Camera MainCamera;
    public Camera BigCamera;
    public Camera SmallCamera;
    public GameObject ArrowSmall;
    public GameObject ArrowBig;
    GameObject SmallArrow;
    GameObject BigArrow;
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
            MainCamera.enabled = false;
            BigCamera.enabled = true;
            SmallCamera.enabled = true;
            spriteRendererSeparator.sprite = SpriteOff;
            SmallArrow = Instantiate(ArrowSmall, transform.position, ArrowSmall.transform.rotation);
            BigArrow = Instantiate(ArrowBig, transform.position, ArrowBig.transform.rotation);
        }

    }



    private void Update()

    {
        if (distanceJoint != null)
        {


            if (Time.time - timer > timeSeparated && distanceJoint.enabled == false)
            {

                boxCollider2D.enabled = true;
                distanceJoint.enabled = true;
                spriteRendererForce.enabled = true;
                separatorActivated = false;

                MainCamera.enabled = true;
                BigCamera.enabled = false;
                SmallCamera.enabled = false;
                spriteRendererSeparator.sprite = SpriteOn;
                Destroy(SmallArrow); 
                Destroy(BigArrow);
            }
        }
    }
    void LookFor()
    {
        BigGuy = GameObject.FindGameObjectWithTag("BigGuy");
        distanceJoint = BigGuy.GetComponent<DistanceJoint2D>();
        spriteRendererForce = Forcefield.GetComponent<SpriteRenderer>();
    }
}
