using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Throw.rock = 0;
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
        Goal.necessaryForGoal = 0;
        Throw.rock = 0;
    }
}   
