using System.Collections;
using ImportedTools;
using UnityEngine;

public class WinScreenController : Singleton<WinScreenController>
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private AudioSource winAudio;
    public bool HasWon => winScreen.activeInHierarchy;

    public void ShowWin()
    {
        if (!winScreen.activeInHierarchy)
        {
            RestartScreenController.Instance.Hide();
            winScreen.SetActive(true);
            if(MusicManager.IsSFXPlaying())
                winAudio.Play();
            StartCoroutine(LoadNextScene());
            LevelTimer.Instance.StopTimer();
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2);
        GameManager.Instance.LoadNextLevel(() => winScreen.SetActive(false));
    }
}