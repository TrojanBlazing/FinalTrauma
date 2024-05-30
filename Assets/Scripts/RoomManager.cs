using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomManager : MonoBehaviour
{
    private Queue<GameObject> roomQueue = new Queue<GameObject>(); // Queue to hold references to rooms

    private GameObject currentRoom; 
    private GameObject previousRoom; 
    public GameObject[] rooms; //array

    public bool inRoom;
   
    private void Start()
    {
        // Initialize the room queue with references to all rooms
        foreach (GameObject room in rooms)
        {
            roomQueue.Enqueue(room);
        }

        // Set the initial room
        currentRoom = roomQueue.Dequeue();
       
    }
    public void SwapRoom()
    {
        if (!inRoom)
        {
            // Deactivate the current room
            if (currentRoom != null)
            {
                currentRoom.SetActive(false);
                // Re-add the current room to the queue
                roomQueue.Enqueue(currentRoom);
            }

            // Update the current room reference
            currentRoom = roomQueue.Dequeue();

            ActivateCurrentRoom();
        }
    }
    private void ActivateCurrentRoom()
    {
        if (currentRoom != null)
        {
            currentRoom.SetActive(true);
        }
    }

    private void DeactivatePreviousRoom()
    {
        if (previousRoom != null)
        {
            previousRoom.SetActive(false);
        }
    }
}




