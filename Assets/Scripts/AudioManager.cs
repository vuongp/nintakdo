using System;
using TMPro;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public TextMeshProUGUI subtitle;
    public Sound[] sounds;

    public int currentSoundIndex = 0;
    public bool playOnAwake = false;
    
    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
        }

        if (playOnAwake)
        {
            sounds[currentSoundIndex].source.Play();
        }
    }

    private void Update()
    {
        if (sounds[currentSoundIndex].source.isPlaying)
        {
            subtitle.text = sounds[currentSoundIndex].GetSubtitleTextForTime(sounds[currentSoundIndex].source.time);
        }
        else
        {
            subtitle.text = "";
        }
    }

    public bool IsPlaying()
    {
        return sounds[currentSoundIndex].source.isPlaying;
    }

    public void Play(string soundName)
    {
        if (IsPlaying())
        {
            sounds[currentSoundIndex].source.Stop();
        }
        currentSoundIndex = Array.FindIndex(sounds, sound => sound.name == soundName);
        sounds[currentSoundIndex].source.Play();
    }
    
}
