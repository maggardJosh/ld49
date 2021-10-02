using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ParticleSystem _particleSystem;


    public void SetActive(bool active)
    {
        _spriteRenderer.color =
            active ? GameManager.Instance.thrusterActiveColor : GameManager.Instance.thrusterInactiveColor;
        if (active)
        {
            if (!_particleSystem.isEmitting)
                _particleSystem.Play();
        }
        else
        {
            if (_particleSystem.isEmitting)
                _particleSystem.Stop();
        }
    }
}