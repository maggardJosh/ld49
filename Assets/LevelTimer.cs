using System;
using ImportedTools;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : Singleton<LevelTimer>
{
    [SerializeField] private TextMeshProUGUI _text;
    private float _time;
    private bool isTimerActive = true;

    public void RestartTimer()
    {
        _time = 0;
        isTimerActive = true;
    }

    public void StopTimer()
    {
        isTimerActive = false;
        SetTimeRecordForLevel(SceneManager.GetActiveScene().name);
    }


    public float GetTime() => _time;

    void Update()
    {
        if (!isTimerActive)
            return;
        
        _time += Time.deltaTime;
        _text.text = $"<mspace=.6em>{SceneManager.GetActiveScene().name}\n {GetTimeString(_time)}</mspace>";
    }

    public static string GetTimeString(float seconds)
    {
        var ts = TimeSpan.FromSeconds(seconds);
        var hoursText = ts.Hours > 0 ? ts.Hours.ToString("00") + ":" : "";
        return $"{hoursText}{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000}";
    }

    private void SetTimeRecordForLevel(string levelString)
    {
        var currentRecord = GetRecordForLevel(levelString);
        if(currentRecord <= 0 || currentRecord > _time)
            PlayerPrefs.SetFloat("Record-" + levelString, _time);
    }
    
    public static float GetRecordForLevel(string levelString)
    {
        return PlayerPrefs.GetFloat("Record-" + levelString, 0);
    }
}
