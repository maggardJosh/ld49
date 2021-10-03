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
    }

    public float GetTime() => _time;

    void Update()
    {
        if (!isTimerActive)
            return;
        
        _time += Time.deltaTime;
        var ts = TimeSpan.FromSeconds(_time);
        var hoursText = ts.Hours > 0 ? ts.Hours.ToString("00") + ":" : "";
        _text.text = $"<mspace=.6em>{SceneManager.GetActiveScene().name}\n {hoursText}{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000}</mspace>";
    }
}
