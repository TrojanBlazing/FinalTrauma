using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitCheck : MonoBehaviour
{
    RoomManager roomManager;

    private void Awake()
    {
        roomManager = FindAnyObjectByType<RoomManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        roomManager.inRoom = true;
       // Debug.Log("in room");
    }

    private void OnTriggerExit(Collider other)
    {
        roomManager.inRoom=false;
        //Debug.Log("not in room");
    }
}
