using ImportedTools;
using UnityEngine;

public class LevelSelect : Singleton<LevelSelect>
{
    [SerializeField] private GameObject levelSelectScreen;
    public bool IsVisible => levelSelectScreen.activeInHierarchy;

    protected override void HandleAwake()
    {
        levelSelectScreen.SetActive(false);
    }

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
            {
                foreach(var button in levelSelectScreen.GetComponentsInChildren<LevelButton>())
                    button.UpdateDisplay();
                levelSelectScreen.SetActive(true);
            }
        }
    }

    public void OnButtonClick(string sceneName)
    {
        levelSelectScreen.SetActive(false);
        GameManager.Instance.LoadScene(sceneName, null);
    }
}
