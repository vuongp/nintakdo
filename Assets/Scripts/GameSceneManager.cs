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
    
    public void loadMainMenu(bool shouldReset)
    {
        if (shouldReset)
        {
            gameInfo = new GameInfo();
        }
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    public void loadNewGame()
    {
        gameInfo.newGameCount += 1;
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public GameInfo GetGameInfo()
    {
        return gameInfo;
    }

    public static GameSceneManager FindGameSceneManager()
    {
        var gameObject = GameObject.FindWithTag("GameSceneManager");
        return gameObject == null ? null : gameObject.GetComponent<GameSceneManager>();
    }

    public void reset()
    {
        gameInfo = new GameInfo();
    }
}