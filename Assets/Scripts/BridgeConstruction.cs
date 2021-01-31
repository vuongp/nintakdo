using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeConstruction : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip constructionAudioClip;
    public AudioClip destructionAudioClip;

    
    public GameObject middleBridge;
    private Slider _bridgeSlider;
    private int previousFrameProgress;

    public List<GameObject> bridgeParts;
    private void Start()
    {
        _bridgeSlider = GetComponent<Slider>();
        bridgeParts = new List<GameObject>();

        Transform t = middleBridge.transform;
        foreach (Transform child in t)
        {
            bridgeParts.Add(child.gameObject);
        }

    }

    private void Update()
    {
        SlideBridgeParts(_bridgeSlider);
    }

    private void SlideBridgeParts(Slider slider)
    {
        if (slider.value > previousFrameProgress) {
            audioSource.Stop();
            audioSource.PlayOneShot(constructionAudioClip);
        }
        else if (slider.value < previousFrameProgress)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(destructionAudioClip);
        }
        previousFrameProgress = (int) slider.value;
        for (int i = 0; i < 10; i++)
        {
            bridgeParts[i].SetActive(i <= slider.value);
        }
    }
}
