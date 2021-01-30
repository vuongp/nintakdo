using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeResetFallScript : MonoBehaviour
{
    public GameObject resetPoint;

    public AudioSource splashAudioSource;
    public AudioSource screamAudioSource;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            splashAudioSource.Play();
            screamAudioSource.Play();
            
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = resetPoint.transform.position;
            other.gameObject.SetActive(true);
        }
    }
}
