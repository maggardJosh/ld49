using ImportedTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public Color thrusterActiveColor;
    public Color thrusterInactiveColor;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadNextLevel()
    {
        var nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex > SceneManager.sceneCount)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
   
}