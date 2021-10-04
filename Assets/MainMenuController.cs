using System.Collections;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;

public class MainMenuController : Singleton<MainMenuController>
{
    [SerializeField] private GameObject mainMenu;

    public bool IsVisible => mainMenu.activeInHierarchy;

    void Awake()
    {
        mainMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsVisible || LevelSelect.Instance.IsVisible || RestartScreenController.Instance.IsShown || ControlsScreenController.Instance.IsVisible)
            Time.timeScale = 0;
        else
        {
            Time.timeScale = 1;
        }
        if (LevelSelect.Instance.IsVisible || RestartScreenController.Instance.IsShown || ControlsScreenController.Instance.IsVisible)
            return;

        if (Input.GetKeyUp(KeyCode.Escape))
            mainMenu.SetActive(!IsVisible);
    }
}