using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SplashHideCoroutine());
    }

    private IEnumerator SplashHideCoroutine()
    {
        yield return new WaitForSeconds(4);
        GameManager.Instance.LoadNextLevel(null, false);

    }
}
