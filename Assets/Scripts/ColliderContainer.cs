using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderContainer : MonoBehaviour
{
    public bool playerInside, playerLeft;
    // Start is called before the first frame update
    void Start()
    {
        playerInside = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerLeft = true;
        }
    }
}
