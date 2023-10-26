using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Menu : MonoBehaviour
{
    public Button PlayButton;
    public Button TutorialButton;
    public Button QuitButton;
    public static RectTransform Cursor;
    public GameObject ChooseCharacterText;
    public Selectable Small;
    public EventSystem eventSystem;
    public Selectable Playbutton;

    public AudioMenu audioManager;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor = GetComponent<RectTransform>();
    }
    void Update()
    {

        

        if (eventSystem.currentSelectedGameObject==null)
        {
            Playbutton.Select();
            
        }
      
    }

    // Update is called once per frame
    public void Play()
    {
        audioManager.ClickingSound();
        SceneManager.LoadScene("MainScene");
        ChooseCharacter();
       // SceneManager.LoadScene("MainScene");
    }
    public void Tutorial()
    {
        audioManager.ClickingSound();
        ChooseCharacter();
    }
    public void Quit()
    {
        audioManager.ClickingSound();
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void ChooseCharacter()
    {
         PlayButton.interactable = false;
        QuitButton.interactable=false;
        TutorialButton.interactable=false;
        ChooseCharacterText.SetActive(true);
        Small.Select();
        Debug.Log(eventSystem.currentSelectedGameObject);
        
    }

}
