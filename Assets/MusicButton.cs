using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
       
    }

    private void UpdateText()
    {
        buttonText.text = MusicManager.IsMusicPlaying() ? "Music Playing" : "Music Muted";
    }

    public void ButtonClick()
    {
        MusicManager.Instance.ToggleMute();
        UpdateText();
    }
}
