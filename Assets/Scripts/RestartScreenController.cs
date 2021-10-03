using ImportedTools;
using UnityEngine;

public class RestartScreenController : Singleton<RestartScreenController>
{
    [SerializeField] private GameObject restartScreen;
    public bool IsShown => restartScreen.activeInHierarchy;

    private void Update()
    {
        if (WinScreenController.Instance.HasWon || LevelSelect.Instance.IsVisible || MainMenuController.Instance.IsVisible)
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
