using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject Rock;
    public GameObject Throwspot;
    AudioManager audioManager;
    private int rock = 0;
    void Start()
    {
        rock = 0;
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }
    public void ThrowHappen()
    {
        if (rock == 0)
        {
            Instantiate(Rock, Throwspot.transform.position, Quaternion.identity);
            rock++;
            audioManager.ThnrowStone();
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            Debug.Log("PickUp");
        audioManager.PickUpStone();
        Destroy(other.gameObject);
        rock--;
        }   
    }
}
