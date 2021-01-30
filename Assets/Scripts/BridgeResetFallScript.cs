using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeResetFallScript : MonoBehaviour
{
    public GameObject resetPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = resetPoint.transform.position;
            other.gameObject.SetActive(true);
        }
    }
}
