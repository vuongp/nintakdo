using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Text subtitle;
    public Sound[] sounds;

    [HideInInspector]
    public Sound currentSound;
    
    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
        }
    }

    private void Start()
    {
        Play("welcome");
    }

    private void Update()
    {
        if (currentSound.source.isPlaying)
        {
            subtitle.text = currentSound.GetSubtitleTextForTime(currentSound.source.time);
        }
    }

    public void Play(string soundName)
    {
        currentSound = Array.Find(sounds, sound => sound.name == soundName);
        currentSound.source.Play();
    }
    
}
