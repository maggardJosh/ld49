using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonController : MonoBehaviour
{
    public void ButtonClick()
    {
        GameManager.Instance.Restart();
    }
}
