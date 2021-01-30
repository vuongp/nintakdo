using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingThemeSong : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clipToLoop;

    private bool clipToLoopEnabled = false;

    // Update is called once per frame
    void Update()
    {
        if (clipToLoopEnabled == false && audioSource.isPlaying == false)
        {
            audioSource.clip = clipToLoop;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
