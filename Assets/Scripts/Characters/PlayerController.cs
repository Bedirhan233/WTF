using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   // public PlayerInputManager inputManager;
    public GameObject playerA;
    public GameObject playerB;
    
    public SpriteRenderer Forcefield;
    
    //PlayerInputManager playerInputManager;

    void Start()
    {
        //playerInputManager = GetComponent<PlayerInputManager>();
        OnPlayerJoined();
    }
  
    public void OnPlayerJoined()
    {
       
        if(Gamepad.all.Count==0)
        {
            var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Small", pairWithDevice: Keyboard.current);
            var player2 = PlayerInput.Instantiate(playerB, controlScheme: "Big", pairWithDevice: Keyboard.current);
        }
        if (Gamepad.all.Count == 1)
        {
            var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[0]);
            var player2 = PlayerInput.Instantiate(playerB, controlScheme: "Big", pairWithDevice: Keyboard.current);
        }
        else if(Gamepad.all.Count == 2)
        {
            var Device = Keyboard.current;
            var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[0]);
            var player2 = PlayerInput.Instantiate(playerB, controlScheme: "Gamepad", pairWithDevice: Gamepad.all[1]);
           
        }
        // Invoke(nameof(ForcefieldEnabled), 0.1f);
        
        //void ForcefieldEnabled()
        //    {
        //    Forcefield.enabled = true;
        //}







     
   
        }
   
}
