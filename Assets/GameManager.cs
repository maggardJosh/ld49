using System;
using System.Collections;
using System.Collections.Generic;
using ImportedTools;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    private bool _isClicking = false;

    private Rigidbody2D _currentBall;

    public Color thrusterActiveColor;
    public Color thrusterInactiveColor;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isClicking = true;
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            _currentBall = Instantiate(ballPrefab, pos, Quaternion.identity).GetComponent<Rigidbody2D>();
            _currentBall.simulated = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            var mouseUpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseUpPos.z = 0;
            var diff = _currentBall.transform.position - mouseUpPos;
            _currentBall.simulated = true;
            _currentBall.velocity = diff.normalized * 40;
            _currentBall = null;
            _isClicking = false;
        }
    }
}