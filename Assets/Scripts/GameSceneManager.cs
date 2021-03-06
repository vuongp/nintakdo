using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    public GameInfo gameInfo = new GameInfo();
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadNewGame()
    {
        gameInfo.newGameCount++;
        SceneManager.LoadScene("Scenes/Intro");
    }
    
    public void LoadLevelScene()
    {
        SceneManager.LoadScene("Scenes/LevelScene");
    }
    /**
     * Example usage of a sceneLoad
     */
    public void LoadMainMenu(bool shouldReset)
    {
        if (shouldReset)
        {
            Reset();
        }
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public GameInfo GetGameInfo()
    {
        return gameInfo;
    }

    public void Reset()
    {
        gameInfo = new GameInfo();
    }
    
    public static GameSceneManager FindGameSceneManager()
    {
        var gameObject = GameObject.FindWithTag("GameSceneManager");
        return gameObject == null ? null : gameObject.GetComponent<GameSceneManager>();
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("Scenes/WinScreen");
    }
}