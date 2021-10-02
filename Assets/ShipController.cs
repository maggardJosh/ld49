using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    [SerializeField] private float thrustPower;
    private SpriteRenderer _leftSprite;
    private SpriteRenderer _rightSprite;

    [SerializeField] private ThrusterData[] thrusterData;

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

    private void Update()
    {
      
    }

    void FixedUpdate()
    {
        
        foreach (var d in thrusterData)
        {
            if (Input.GetKey(d.key))
            {
                _rigidBody.AddForceAtPosition(d.controller.transform.rotation * Vector2.up * thrustPower, d.controller.transform.position);
                d.controller.SetActive(true);
            }
            else
            {
                d.controller.SetActive(false);
            }
        }

        
    }
}