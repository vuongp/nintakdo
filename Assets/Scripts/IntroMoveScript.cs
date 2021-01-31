using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMoveScript : MonoBehaviour
{
    public AudioManager audioManager;
    private GameSceneManager _gameSceneManager;

    // Update is called once per frame
    private void Start()
    {
        _gameSceneManager = GameSceneManager.FindGameSceneManager();
    }

    void Update()
    {
        if (!audioManager.IsPlaying())
        {
            _gameSceneManager.LoadLevelScene();
        }
    }
    
}
