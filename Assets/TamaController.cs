using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private Vector2 _storedVel = Vector2.zero;

    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Shrink()
    {
        _animator.SetTrigger("shrink");
    }

    public void Show(Vector2 pos, Vector2 vel)
    {
        transform.position = pos;
        _rigidBody.bodyType = RigidbodyType2D.Static;
        _storedVel = vel;
        _animator.SetTrigger("show");
        gameObject.SetActive(true);
    }

    public void SetStoredVel()
    {
        _rigidBody.bodyType = RigidbodyType2D.Dynamic;
        _rigidBody.velocity = _storedVel;
        _rigidBody.angularVelocity = 0;
    }
}
