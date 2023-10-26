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
            OnPlayerJoined(0);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            OnPlayerJoined(1);
        }
    }
    public void OnPlayerJoined(int Control)
    {
        Gamepad device1;
        Gamepad device2;
        i++;
        if (i == 1)
        {
            //InputSystem.AddDevice<Gamepad>("1");
            device1 = InputSystem.AddDevice<Gamepad>("1");
        }
        if (i == 2)
        {
            device2 = InputSystem.AddDevice<Gamepad>("2");

            //InputSystem.AddDevice<Gamepad>("2");
        }

      
        
        //foreach (var item in InputSystem.devices)
        //{
        //    Debug.Log(item.deviceId);
        //}
        //Debug.Log(InputSystem.devices[0].deviceId);
        //  inputManager.playerPrefab = playerPrefabB;
        if (i==1)
        { 
            if(Control == 0)
            {
                var Device = Keyboard.current;
                var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Small", pairWithDevice: Device);
            }
            if (Control == 1)
            {
                var Device = Gamepad.current;
                var player1 = PlayerInput.Instantiate(playerA, controlScheme: "Gamepad", pairWithDevice: Device);
            }
            
        
        }
      
        if (i==2)
        {
            var player2 = PlayerInput.Instantiate(playerB, controlScheme: "Big", pairWithDevice: Keyboard.current);
            Forcefield.enabled = true;  
        }

        }
   
}
