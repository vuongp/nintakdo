using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeConstruction : MonoBehaviour
{
    public AudioSource constructionAudioSource;
    public AudioSource destructionAudioSource;
    
    public GameObject middleBridge;
    private Slider _bridgeSlider;

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
        for (int i = 0; i < 10; i++)
        {
            bridgeParts[i].SetActive(i <= slider.value);
        }
    }
}
