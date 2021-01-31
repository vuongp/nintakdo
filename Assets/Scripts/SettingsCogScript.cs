using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SettingsCogScript : MonoBehaviour
{
    public GameObject popupGameObject;
    public GameObject crosshair;
    
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
            if (popupGameObject.activeSelf)
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
        popupGameObject.SetActive(true);
        _firstPersonController.GetMouseLook().SetCursorLock(false);
        _firstPersonController.enabled = false;
        crosshair.SetActive(false);
    }

    public void CloseSettings()
    {
        popupGameObject.SetActive(false);
        _firstPersonController.GetMouseLook().SetCursorLock(true);
        _firstPersonController.enabled = true;
        crosshair.SetActive(true);
    }
}
