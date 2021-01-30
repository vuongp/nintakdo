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
        if (slider.value == 1)
        {
            bridgeParts[0].SetActive(true);
        } else if (slider.value == 2)
        {
            bridgeParts[1].SetActive(true);
        } else if (slider.value == 3)
        {
            bridgeParts[2].SetActive(true);
        } else if (slider.value == 4)
        {
            bridgeParts[3].SetActive(true);
        } else if (slider.value == 5)
        {
            bridgeParts[4].SetActive(true);
        } else if (slider.value == 6)
        {
            bridgeParts[5].SetActive(true);
        } else if (slider.value == 7)
        {
            bridgeParts[6].SetActive(true);
        } else if (slider.value == 8)
        {
            bridgeParts[7].SetActive(true);
        } else if (slider.value == 9)
        {
            bridgeParts[8].SetActive(true);
        } else if (slider.value == 10)
        {
            bridgeParts[9].SetActive(true);
        }
        else
        {
            foreach (GameObject go in bridgeParts)
            {
                go.SetActive(false);
            }
        }
        
        
    }
}
