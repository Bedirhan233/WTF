using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public static int nextScene=3;
    public static int necessaryForGoal=0;
    public static bool smallEnteredGoal = false;
    public static bool bigEnteredGoal = false;

    void Start()
    {
        smallEnteredGoal = false;
        bigEnteredGoal=false;
        necessaryForGoal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
       
        if (other.gameObject.tag=="SmalGuy")
        {
            smallEnteredGoal = true;
          
        }
       else if (other.gameObject.tag == "BigGuy")
        {
            bigEnteredGoal = true;
           
        }

        if ((smallEnteredGoal==true)&&(bigEnteredGoal==true))
        {
            
            SceneManager.LoadScene(nextScene);
            nextScene = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        smallEnteredGoal=false;
        bigEnteredGoal=false;

    }
}
