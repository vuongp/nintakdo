using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManagerInstantiator : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameSceneManager gameSceneManager;
    private void Awake()
    {
        var sceneManager = GameSceneManager.FindGameSceneManager();
        if (sceneManager == null)
        {
            Instantiate(gameSceneManager, new Vector3(0, 0, 0), Quaternion.identity);   
        }
    }

    public void MoveToLevelScene()
    {
        gameSceneManager.LoadNewGame();
    }
}
