using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Play()
    {
        ChooseCharacter();
    }
    public void Tutorial()
    {
        ChooseCharacter();
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void ChooseCharacter()
    {
        
    }

}
