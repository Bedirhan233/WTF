using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static RectTransform Cursor;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor = GetComponent<RectTransform>();
    }
    void Update()
    {
        
      
    }

    // Update is called once per frame
    public void Play()
    {
        ChooseCharacter();
        SceneManager.LoadScene("MainScene");
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
