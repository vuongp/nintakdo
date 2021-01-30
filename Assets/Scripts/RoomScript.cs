using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RoomScript : MonoBehaviour
{
    public GameObject nextRoom;
    public GameObject player;
    bool active;
    public bool firstroom = false;

    // Start is called before the first frame update
    void Start()
    {
        active = firstroom;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.Q)) { LevelComplete(); }
        }
    }

    void LevelComplete
  ()
    {
        if (nextRoom != null) {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = nextRoom.transform.Find("Spawn Point").transform.position + new Vector3(0,1,0);
            nextRoom.GetComponent<RoomScript>().active = true;
            active = false;
            player.GetComponent<CharacterController>().enabled = true;
        } else
        {
            //TODO:Win
        }
    }
}
