using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RoomScript : MonoBehaviour
{
    public GameObject nextRoom;
    public GameObject player;
    public bool active;
    public bool firstroom = false;
    private GameSceneManager _gameSceneManager;
    public NarratorScript narratorScript; 

    // Start is called before the first frame update
    void Start()
    {
        _gameSceneManager = GameSceneManager.FindGameSceneManager();
        active = firstroom;
    }
    
    public void LevelComplete()
    {
        if (nextRoom != null) {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = nextRoom.transform.Find("Spawn Point").transform.position + new Vector3(0,1,0);
            nextRoom.GetComponent<RoomScript>().active = true;
            active = false;
            player.GetComponent<CharacterController>().enabled = true;
            if (narratorScript != null)
            {
                narratorScript.NextLevel();
            }
        } else
        {
            _gameSceneManager.LoadWinScreen();
        }
    }
}
