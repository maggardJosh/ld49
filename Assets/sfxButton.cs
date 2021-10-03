using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sfxButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
       
    }

    private void UpdateText()
    {
        buttonText.text = MusicManager.IsSFXPlaying() ? "SFX Playing" : "SFX Muted";
    }

    public void ButtonClick()
    {
        MusicManager.Instance.ToggleSFXMute();
        UpdateText();
    }
}
