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
        LevelTransition.Instance.HideLevel(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LevelTransition.Instance.ShowLevel();
        });
    }

    public void LoadNextLevel(Action onLoadAction)
    {
        LevelTransition.Instance.HideLevel(() =>
        {
            var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
                nextSceneIndex = 0;
            SceneManager.LoadScene(nextSceneIndex);
            onLoadAction?.Invoke();
            LevelTransition.Instance.ShowLevel();
        });
    }
}