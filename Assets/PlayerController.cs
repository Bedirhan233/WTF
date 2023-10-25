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
    public SpriteRenderer Forcefield;
    private int i = 0;
    public void OnPlayerJoined(PlayerInput input)
    {
        i++;
            inputManager.playerPrefab = playerPrefabB;
        if (i==2)
        {
            Forcefield.enabled = true;
        }

        }
   
}
