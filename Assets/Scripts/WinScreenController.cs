using System.Collections;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;

public class WinScreenController : Singleton<WinScreenController>
{
    [SerializeField] private GameObject winScreen;

    public void ShowWin()
    {
        if (!winScreen.activeInHierarchy)
        {
            winScreen.SetActive(true);
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2);
        GameManager.Instance.LoadNextLevel(() => winScreen.SetActive(false));
    }
}