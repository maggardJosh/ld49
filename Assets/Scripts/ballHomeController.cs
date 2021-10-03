using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballHomeController : MonoBehaviour
{
    private float _stayCount = 0;
    private bool _tamaIsInCollider = false;
    public float StayToWinSeconds = 3;
    public AnimationCurve showWinCurve;
    [SerializeField] private SpriteRenderer winSpriteRend;

    private void Update()
    {
        if (_tamaIsInCollider)
        {
            _stayCount += Time.deltaTime;
            Color winColor = Color.white;
            var value = showWinCurve.Evaluate(_stayCount / StayToWinSeconds);
            winColor.a = value;
            winSpriteRend.color = winColor;
        }
        else
        {
            _stayCount = 0;
            winSpriteRend.color = Color.clear;
        }
        
        
        if(_stayCount >= StayToWinSeconds)
        {
            WinScreenController.Instance.ShowWin();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Tama"))
            return;
        _tamaIsInCollider = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Tama"))
            return;
        _tamaIsInCollider = false;
    }
}
