using System;
using ImportedTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Color thrusterActiveColor;
    public Color thrusterInactiveColor;

    private void Start()
    {
        RefreshKeyCodes();
    }

    public void RefreshKeyCodes()
    {
        string playerfValue = PlayerPrefs.GetString("fkey", KeyCode.F.ToString());
        if (!KeyCode.TryParse(playerfValue, out fKey))
            fKey = KeyCode.F;
        
        string playervValue = PlayerPrefs.GetString("vkey", KeyCode.V.ToString());
        if (!KeyCode.TryParse(playervValue, out vKey))
            vKey = KeyCode.V;
        
        string playerjValue = PlayerPrefs.GetString("jkey", KeyCode.J.ToString());
        if (!KeyCode.TryParse(playerjValue, out jKey))
            jKey = KeyCode.J;
        
        string playernValue = PlayerPrefs.GetString("nkey", KeyCode.N.ToString());
        if (!KeyCode.TryParse(playernValue, out nKey))
            nKey = KeyCode.N;
    }

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

    public KeyCode fKey = KeyCode.F;
    public KeyCode vKey = KeyCode.V;
    public KeyCode nKey = KeyCode.N;
    public KeyCode jKey = KeyCode.J;

}