using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] private float thrustPower;
    private SpriteRenderer _leftSprite;
    private SpriteRenderer _rightSprite;

    [SerializeField] private ThrusterData[] thrusterData;
    [SerializeField] private AudioSource _thrusterSource;

    [Serializable]
    public class ThrusterData
    {
        public ThrusterController controller;
        public KeyCode key;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }



    void FixedUpdate()
    {
        bool thrusterActive = false;
        foreach (var d in thrusterData)
        {
            KeyCode actualKey = GetInputKey(d.key);
            if (Input.GetKey(actualKey))
            {
                _rigidBody.AddForceAtPosition(d.controller.transform.rotation * Vector2.up * thrustPower, d.controller.transform.position);
                d.controller.SetActive(true);
                thrusterActive = true;
            }
            else
            {
                d.controller.SetActive(false);
            }
        }

        _thrusterSource.mute = !MusicManager.IsSFXPlaying() || !thrusterActive;

    }

    private KeyCode GetInputKey(KeyCode dKey)
    {
        switch (dKey)
        {
            case KeyCode.F: return GameManager.Instance.fKey;
            case KeyCode.V: return GameManager.Instance.vKey;
            case KeyCode.J: return GameManager.Instance.jKey;
            case KeyCode.N: return GameManager.Instance.nKey;
            default: return dKey;
        }
    }
}