using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Portal : MonoBehaviour
{
    
          GameObject BigGuy;
    public GameObject PortalVisual;
    static int onPortal = 0;
    static float timeOnPortal;
    bool portalVisualExists = false;
    GameObject ProtalesVisuales;
    float personalTimeOnPortal;
    GameObject EnteredObject;
    public float timeBeforeTeleport=1.4f;
    void Start()
    {
        
        
            Invoke(nameof(LookFor), 0.5f);

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (portalVisualExists&&ProtalesVisuales!=null)
        {
            ProtalesVisuales.transform.position = transform.localPosition + new Vector3(14.8f, -3.4f, 0);
            timeOnPortal += Time.deltaTime;
            personalTimeOnPortal += Time.deltaTime;
            if (timeOnPortal > timeBeforeTeleport && personalTimeOnPortal > timeBeforeTeleport)
            {
                if (EnteredObject != null)
                {
                        
                    if (EnteredObject.CompareTag("SmallGuy") && onPortal == 2)
                    {

                        var bigGuyTransformPos = BigGuy.transform.position;
                        var smallGuyTransformPos = EnteredObject.transform.position;
                        BigGuy.transform.position = smallGuyTransformPos;
                        EnteredObject.transform.position=bigGuyTransformPos;
                      
                        Destroy(ProtalesVisuales);
                        timeOnPortal = 0;
                        personalTimeOnPortal = 0;
                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnteredObject = other.gameObject;
        if (other.gameObject.CompareTag(gameObject.tag + "Guy"))
        {

            if (!portalVisualExists)
            {
                onPortal++;
                portalVisualExists = true;
                ProtalesVisuales = Instantiate(PortalVisual,transform.localPosition+new Vector3(14.8f,-3.4f,0), Quaternion.identity);
            }


        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(gameObject.tag + "Guy"))
        {
            onPortal--;
            portalVisualExists = false;
            timeOnPortal = 0;
            if (ProtalesVisuales != null)
                Destroy(ProtalesVisuales);
        }


    }
    void LookFor()
    {
        BigGuy = GameObject.FindGameObjectWithTag("BigGuy");
       
    }
}
