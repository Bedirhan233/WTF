using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cursor : MonoBehaviour, ISelectHandler
{

    
    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;
    Selectable button;
    // Start is called before the first frame update
    void Start()
    {
       button = GetComponent<Selectable>();
            
    }

    // Update is called once per frame
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(eventData.selectedObject.name);
        Menu.Cursor.position = transform.position+new Vector3(-200,30,0);
        //cursor.position = position1;
        
    }
    public void OnSelectTut()
    {
        //cursor.position = position2;

    }

    public void OnSelectQuit()
    {
        //  cursor.position = position3;

    }
}
