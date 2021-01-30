using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraForward : MonoBehaviour
{
    [Range(0f, 100f)]
    public float speed = 10f;

    public float moveToMainScreenThreshold = 160f;
    private GameSceneManager _gameSceneManager;

    // Update is called once per frame
    private void Start()
    {
        _gameSceneManager = GameSceneManager.FindGameSceneManager();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * speed));

        if (gameObject.transform.position.z > moveToMainScreenThreshold)
        {
            speed = 0f;
            _gameSceneManager.loadMainMenu(true);
        }
    }
}
