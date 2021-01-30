using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeWinTriggerScript : MonoBehaviour
{
    public RoomScript rs;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            rs.LevelComplete();
            other.gameObject.SetActive(true);
        }
    }
}
