using System;
using UnityEngine;

public class LevelTransitionController : MonoBehaviour
{
    
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private Action _onHideAction;
    private Animator _animator;
    private bool IsShowing => _animator.GetBool("show");
    
    
    public void HideLevel(Action onHideAction)
    {
        if (!IsShowing)
            return;
        _animator.SetBool("show", false);
        _onHideAction = onHideAction;
    }

    public void OnHide()
    {
        _onHideAction?.Invoke();
        _onHideAction = null;
    }

    public void ShowLevel()
    {
        if (IsShowing)
            return;
        _animator.SetBool("show", true);
    }
}
