using ImportedTools;
using UnityEngine;

public class LevelSelect : Singleton<LevelSelect>
{
    [SerializeField] private GameObject levelSelectScreen;
    public bool IsVisible => levelSelectScreen.activeInHierarchy;

    private void Update()
    {
        if (RestartScreenController.Instance.IsShown || WinScreenController.Instance.HasWon)
            return;
        if (levelSelectScreen.activeInHierarchy)
        {
            if(Input.GetKeyUp(KeyCode.Escape))
                levelSelectScreen.SetActive(false);
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.Escape))
                levelSelectScreen.SetActive(true);
        }
    }

    public void OnButtonClick(string sceneName)
    {
        levelSelectScreen.SetActive(false);
        GameManager.Instance.LoadScene(sceneName, null);
    }
}
