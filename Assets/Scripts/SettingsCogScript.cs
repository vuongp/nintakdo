using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SettingsCogScript : MonoBehaviour
{
    public GameObject gameObject;
    
    public GameObject playerObject;
    private FirstPersonController _firstPersonController;

    private void Start()
    {
        _firstPersonController = playerObject.GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F1))
        {
            if (gameObject.activeSelf)
            {
                CloseSettings();
            }
            else
            {
                ShowSettings();
            }
        }
    }

    public void ShowSettings()
    {
        gameObject.SetActive(true);
        _firstPersonController.GetMouseLook().SetCursorLock(false);
        _firstPersonController.enabled = false;
    }

    public void CloseSettings()
    {
        gameObject.SetActive(false);
        _firstPersonController.GetMouseLook().SetCursorLock(true);
        _firstPersonController.enabled = true;
    }
}
