using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Tether BigGuysTether;
    public GameObject BigGuy;
    bool portalOn;
    void Start()
    {
        Invoke("LookFor", 0.5f);
        portalOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="SmalGuy"&&portalOn)
        {
            BigGuy.transform.position = other.transform.position;
            portalOn = false;
            var smallTransform = other.gameObject.transform;
            BigGuysTether.ChangePlace(transform);
        }
        
    }
    void LookFor()
    {
        GameObject BigGuy = GameObject.FindGameObjectWithTag("BigGuy");
        BigGuysTether =BigGuy.GetComponent<Tether>();
    }
}
