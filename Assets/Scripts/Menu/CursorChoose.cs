using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorChoose : MonoBehaviour, ISelectHandler
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
        Menu.Cursor.position = transform.position + new Vector3(0, 30, 0);
        Menu.Cursor.rotation =Quaternion.Euler(0,0,-90) ;
        //cursor.position = position1;
      
    }
}