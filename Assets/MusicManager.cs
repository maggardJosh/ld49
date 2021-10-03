using System.Collections;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] private AudioSource _audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        UpdateMute();
    }

    private void UpdateMute()
    {
        _audioSource.mute = !IsMusicPlaying();
    }

    public void ToggleMute()
    {
        PlayerPrefs.SetInt("musicMute", IsMusicPlaying() ? 1 : 0);
        UpdateMute();
    }

    public static bool IsMusicPlaying()
    {
        return PlayerPrefs.GetInt("musicMute", 0) == 0;
    }

    public static bool IsSFXPlaying()
    {
        return PlayerPrefs.GetInt("sfxMute", 0) == 0;
    }

    public void ToggleSFXMute()
    {
        PlayerPrefs.SetInt("sfxMute", IsSFXPlaying() ? 1 : 0);
    }
}