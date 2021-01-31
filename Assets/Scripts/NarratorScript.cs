using System;
using UnityEngine;

public class NarratorScript : MonoBehaviour
{

    public AudioManager audioManager;

    public float timeBetweenHints = 15;

    public int currentLevel = 0;

    public LevelHints[] levelHints = new LevelHints[0];

    private float lastHintTime = 0f;
    private int hintsGivenThisLevel = 0;
    
    void FixedUpdate()
    {
        if (GetTimePastSinceLastHint() >= timeBetweenHints)
        {
            lastHintTime = Time.timeSinceLevelLoad;
            if (currentLevel > levelHints.Length)
            {
                return;
            }

            var levelHint = levelHints[currentLevel];
            audioManager.Play(levelHint.audioHintNames[hintsGivenThisLevel % levelHint.audioHintNames.Length]);
            hintsGivenThisLevel++;
        }
    }

    public float GetTimePastSinceLastHint()
    {
        return Time.timeSinceLevelLoad - lastHintTime;
    }

    public void NextLevel()
    {
        currentLevel++;
        lastHintTime = Time.timeSinceLevelLoad;
        hintsGivenThisLevel = 0;
    }
}

[System.Serializable]
public class LevelHints
{
    public String[] audioHintNames;
}
