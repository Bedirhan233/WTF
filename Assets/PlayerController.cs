using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputManager inputManager;
    public GameObject playerA;
    public GameObject playerB;
    public GameObject playerPrefabB;

    public void OnPlayerJoined(PlayerInput input)
    {
        
            inputManager.playerPrefab = playerPrefabB;
        }
   
}
