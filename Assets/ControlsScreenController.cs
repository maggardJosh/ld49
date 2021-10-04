using System.Collections;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;

public class ControlsScreenController : Singleton<ControlsScreenController>
{
    [SerializeField] private GameObject controlsScreen;

    public bool IsVisible => controlsScreen.activeInHierarchy;
    
    void Start()
    {
        controlsScreen.SetActive(false);
    }

    public void ResetControls()
    {
        PlayerPrefs.DeleteKey("fkey");
        PlayerPrefs.DeleteKey("vkey");
        PlayerPrefs.DeleteKey("jkey");
        PlayerPrefs.DeleteKey("nkey");
        GameManager.Instance.RefreshKeyCodes();
        foreach(var c in GetComponentsInChildren<ControlButton>())
            c.UpdateButton();
    }

}
