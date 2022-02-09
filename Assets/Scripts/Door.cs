using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool isLocked = false;
    public int goesTo = 0; //set in the inspector

    public Vector2 playerPosition;
    public VectorValue playerStorage;

    //While triggered by the Players Presence the door will wait for the 'E' key to be pressed. When it receives the required input, runs the open door function.
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        if(!isLocked)
        {
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(goesTo);
        }
        else
        {
            Debug.Log("You Need To Find A Key");
        }
        
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }
    //Open Door
    //If locked, Inform Player that a Key is needed.
    //if Player already has the Key in their inventory, provide option to unlock.
    //If Player chooses to Unlock the door, LoadScene(goesTo).
    //If Player chooses to leave the door, stay in current scene.

    //UseStairs
    //If the Player opens a door which leads to stairs:
    //If the Player is on the lowest floor, move up a floor.
    //If the Player is on a floor in the middle, offer choice to move up or down.
    //If the player is on the highest floor, move down a floor.
}
