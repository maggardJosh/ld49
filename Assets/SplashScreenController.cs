using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    [SerializeField] private float splashSeconds = 4f;
    void Start()
    {
        StartCoroutine(SplashHideCoroutine());
    }

    private IEnumerator SplashHideCoroutine()
    {
        yield return new WaitForSeconds(splashSeconds);
        GameManager.Instance.LoadNextLevel(null, false);

    }
}
