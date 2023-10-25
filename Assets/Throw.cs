using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject Rock;
    public GameObject Throwspot;
    private int rock = 0;
    void Start()
    {
        rock = 0;
    }
    public void ThrowHappen()
    {
        if (rock == 0)
        {
            Instantiate(Rock, Throwspot.transform.position, Quaternion.identity);
            rock++;
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        { 
        Destroy(other.gameObject);
        rock--;
        }   
    }
}
