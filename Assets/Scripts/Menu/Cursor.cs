using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Cursor : MonoBehaviour, ISelectHandler
{


    Selectable button;
    // Start is called before the first frame update
    void Start()
    {
        Goal.nextScene = 3;
        button = GetComponent<Selectable>();
            
    }

    // Update is called once per frame
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log(eventData.selectedObject.name); 
        Menu.Cursor.position = transform.position+new Vector3(-200,30,0);
        //cursor.position = position1;
        
    }
  
}
