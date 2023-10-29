using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject target;
    public float smoothing;

    public Vector2 maxPos;
    public Vector2 minPos;
    public bool onCharacter=false;
    public bool isSmall = false;
 
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && onCharacter == false)
        {
            target = GameObject.FindGameObjectWithTag("Forcefield");
        }
        else if (target == null && onCharacter == true)
        {
            if(isSmall)
            {
            target=GameObject.FindGameObjectWithTag("SmallGuy");
            }
            
            else if(isSmall==false)
            {
                target = GameObject.FindGameObjectWithTag("BigGuy");
            }
           
        }

        else if (transform.position != target.transform.position)
        {
            Vector3 targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }
     

    }
}
