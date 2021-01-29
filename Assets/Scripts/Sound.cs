using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public Subtitle[] subtitles;
    
    [HideInInspector]
    public AudioSource source;

    public string GetSubtitleTextForTime(float timeInSeconds)
    {
        string subtitleToShow = null;
        foreach (var subtitle in subtitles)
        {
            if (subtitle.timestampInSeconds <= timeInSeconds)
            {
                subtitleToShow = subtitle.text;
            }
        }

        return subtitleToShow;
    }
}