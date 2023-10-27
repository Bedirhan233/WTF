using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   // public PlayerInputManager inputManager;
    public GameObject playerA;
    public GameObject playerB;
    public GameObject playerPrefabB;
    public SpriteRenderer Forcefield;
    private int i = 0;  
    

    void Start()
    {
        OnPlayerJoined();
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        OnPlayerJoined(0);
    //    }
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        OnPlayerJoined(1);
    //    }
    //}
    public void OnPlayerJoined()
    {
        if (Menu.controls==0)
        {
            var Device = Gamepad.current;
            var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Gamepad", pairWithDevice: Device);
            var player2 = PlayerInput.Instantiate(playerB, controlScheme: "Big", pairWithDevice: Keyboard.current);
            Invoke("ForcefieldEnabled", 0.1f);
        }
        else if(Menu.controls == 1)
        {
            var Device = Keyboard.current;
            var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Small", pairWithDevice: Device);
            var player2 = PlayerInput.Instantiate(playerB, controlScheme: "Big", pairWithDevice: Keyboard.current);
            Invoke("ForcefieldEnabled", 0.1f);
        }
        
        
        void ForcefieldEnabled()
            {
            Forcefield.enabled = true;
        }







     
        //if (i==1)
        //{ 
        //    if(Control == 0)
        //    {
        //        var Device = Keyboard.current;
        //        var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Small", pairWithDevice: Device);
        //    }
        //    if (Control == 1)
        //    {
        //        var Device = Gamepad.current;
        //        var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Gamepad", pairWithDevice: Device);
        //    }
            
        
        //}
      
        //if (i==2)
        //{
        //    var player2 = PlayerInput.Instantiate(playerB, controlScheme: "Big", pairWithDevice: Keyboard.current);
        //    Forcefield.enabled = true;  
        //}

        }
   
}
