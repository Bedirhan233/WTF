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
    public TextMeshProUGUI PlayButtonText;
    public TextMeshProUGUI TutorialButtonText;
    public TextMeshProUGUI QuitButtonText;
    public static RectTransform Cursor;
    public GameObject ChooseCharacterText;
    public Button Small;
    public EventSystem eventSystem;
    public Button Big;
    public static int sceneIndex;
    public static int controls;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor = GetComponent<RectTransform>();
        Big.interactable = false;
        Small.interactable= false;
    }
    void Update()
    {

        

        if (eventSystem.currentSelectedGameObject==null)
        {
            PlayButton.Select();
            
        }
      
    }

    // Update is called once per frame
    public void Play()
    {
            
        ChooseCharacter(2);
       // SceneManager.LoadScene("MainScene");
    }
    public void Tutorial()
    {
        ChooseCharacter(3);
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void ChooseCharacter(int scene)
    {
         PlayButton.interactable = false;
        QuitButton.interactable=false;
        TutorialButton.interactable=false;
        PlayButtonText.enabled = false;
        TutorialButtonText.enabled = false;
        QuitButtonText.enabled = false;
        ChooseCharacterText.SetActive(true);
        Small.interactable = true;
        Big.interactable = true; 
        Cursor.position = new Vector3(-416, -176, 0) + new Vector3(0, 30, 0);
        Invoke("Small.Select",0.5f);
       
        sceneIndex = scene;
        Debug.Log(eventSystem.currentSelectedGameObject);
       
    }
    public void LoadSceneController()
    {
        SceneManager.LoadScene(sceneIndex);
        controls = 0;

    }
    public void LoadSceneSplit()
    {
        SceneManager.LoadScene(sceneIndex);
        controls = 1;
    }
}
