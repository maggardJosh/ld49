using System;
using System.Collections;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;

public class RestartScreenController : Singleton<RestartScreenController>
{
    [SerializeField] private GameObject restartScreen;

    private void Update()
    {
        if (WinScreenController.Instance.HasWon)
            return;
        
        if (restartScreen.activeInHierarchy)
        {
            if(Input.GetKeyUp(KeyCode.R))
            {
                GameManager.Instance.Restart();
                restartScreen.SetActive(false);
            }

            if (Input.GetKeyUp(KeyCode.Escape))
                restartScreen.SetActive(false);
            return;
        }

        if(Input.GetKeyUp(KeyCode.R))
            restartScreen.SetActive(true);
    }

    public void Hide()
    {
        restartScreen.SetActive(false);
    }
}
