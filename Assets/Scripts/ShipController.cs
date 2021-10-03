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
            if (Input.GetKey(d.key))
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
}