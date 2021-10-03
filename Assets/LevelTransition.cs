using System;
using ImportedTools;
using UnityEngine;

public class LevelTransition : Singleton<LevelTransition>
{
    [SerializeField] private LevelTransitionController _controller;

    protected override void HandleAwake()
    {
    }

    private void Start()
    {
        ShowLevel();
    }

    public void HideLevel(Action onHideAction)
    {
        _controller.HideLevel(onHideAction);
    }


    public void ShowLevel()
    {
        _controller.ShowLevel();
    }
}
