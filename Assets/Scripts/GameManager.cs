using System;
using ImportedTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Color thrusterActiveColor;
    public Color thrusterInactiveColor;

    public void Restart()
    {
        if (WinScreenController.Instance.HasWon)
            return;
        LevelTransition.Instance.HideLevel(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LevelTransition.Instance.ShowLevel();
            LevelTimer.Instance.RestartTimer();
        });
    }

    public void LoadNextLevel(Action onLoadAction, bool useTimer = true)
    {
        LevelTransition.Instance.HideLevel(() =>
        {
            var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
                nextSceneIndex = 1; //Skip title
            SceneManager.LoadScene(nextSceneIndex);
            onLoadAction?.Invoke();
            LevelTransition.Instance.ShowLevel();
            if(useTimer)
                LevelTimer.Instance.RestartTimer();
        });
    }

    public void LoadScene(string sceneName, Action onLoadAction)
    {
        LevelTransition.Instance.HideLevel(() =>
        {
            SceneManager.LoadScene(sceneName);
            onLoadAction?.Invoke();
            LevelTransition.Instance.ShowLevel();
            LevelTimer.Instance.RestartTimer();
        });
    }
}