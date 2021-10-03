using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float fadeInTime = 1f;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
        
    }

    private float count = 0;

    [SerializeField] private AnimationCurve _curve;

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= fadeInTime)
        {
            _audioSource.volume = 1;
            Destroy(this);
            return;
        }

        _audioSource.volume = _curve.Evaluate(count / fadeInTime);
    }
}
