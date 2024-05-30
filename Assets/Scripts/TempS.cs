using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class TempS : MonoBehaviour
{
    //public static LobbyLoop lobbyManager;
    int doorOpen = 0; 
    RoomManager roomManager;

    private void Awake()
    {
        roomManager = GameObject.FindGameObjectWithTag("RoomGeneration").GetComponent<RoomManager>();
    }
    public void DoorOpenAnimTrigger()
    {
        doorOpen = 1;
        //lobbyManager.SpawnNextLobby(transform);
    }

    public void DoorCloseAnimTrigger()
    {
        doorOpen = -1;
        roomManager.SwapRoom();
    }
}
