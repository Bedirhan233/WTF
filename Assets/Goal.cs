using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public string character;
    public static int necessaryForGoal;
    bool enteredgoal = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag==character && enteredgoal==false)
        {
            Goal.necessaryForGoal++;
            enteredgoal = true;
        }
        if(Goal.necessaryForGoal==2)
        {
            SceneManager.LoadScene(3);
        }
    }
}
