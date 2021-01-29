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

    /**
     * Example usage of a sceneLoad
     */
    public void loadSampleScene(string testInfo)
    {
        gameInfo.testInfo = testInfo;
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
}