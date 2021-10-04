using System;
using TMPro;
using UnityEngine;

public class ControlButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private bool isListening = false;
    public string keyValue = "fkey";
    public KeyCode defaultValue = KeyCode.F;



    public void OnClick()
    {
        if (isListening)
        {
            isListening = false;
            UpdateButton();
            return;
        }

        isListening = true;
        UpdateButton();

    }

    public void UpdateButton()
    {
        if (isListening)
        {
            text.text = "?";
            return;
        }

        text.text = PlayerPrefs.GetString(keyValue, defaultValue.ToString());
        return;


    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateButton();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ControlsScreenController.Instance.IsVisible)
        {
            if (isListening)
                isListening = false;
        }

        if (!isListening)
            return;
        
        foreach(KeyCode v in Enum.GetValues(typeof(KeyCode)))
        {
            if (v == KeyCode.Mouse0)
                continue;
            if (Input.GetKeyUp(v))
            {
                isListening = false;
                PlayerPrefs.SetString(keyValue, v.ToString());
                GameManager.Instance.RefreshKeyCodes();
                UpdateButton();
                return;
            }
        }

    }
}
