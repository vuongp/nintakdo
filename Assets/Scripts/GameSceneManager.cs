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
    
    public void loadNewGame()
    {
        gameInfo.newGameCount++;
        SceneManager.LoadScene("Scenes/Puzzle_Bridge");
    }
    /**
     * Example usage of a sceneLoad
     */
    public void loadMainMenu(bool shouldReset)
    {
        if (shouldReset)
        {
            reset();
        }
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public GameInfo GetGameInfo()
    {
        return gameInfo;
    }

    public void reset()
    {
        gameInfo = new GameInfo();
    }
    
    public static GameSceneManager FindGameSceneManager()
    {
        var gameObject = GameObject.FindWithTag("GameSceneManager");
        return gameObject == null ? null : gameObject.GetComponent<GameSceneManager>();
    }

}