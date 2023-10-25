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
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            OnPlayerJoined();
        }
    }
    public void OnPlayerJoined()
    {
        i++;
          //  inputManager.playerPrefab = playerPrefabB;
        if(i==1)
        { 
        var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Small", pairWithDevice: Keyboard.current);
        }
      
        if (i==2)
        {
            var player2 = PlayerInput.Instantiate(playerB, controlScheme: "Big", pairWithDevice: Keyboard.current);
            Forcefield.enabled = true;
        }

        }
   
}
