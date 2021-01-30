using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject gameResetObject;
    
    private GameSceneManager _gameSceneManager;

    private void Start()
    {
        _gameSceneManager = GameSceneManager.FindGameSceneManager();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            _gameSceneManager.reset();
            gameResetObject.SetActive(true);
        }
    }

    public void NewGame()
    {
        GameSceneManager.FindGameSceneManager().loadNewGame();
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
