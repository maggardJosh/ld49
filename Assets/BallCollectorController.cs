using UnityEngine;

public class BallCollectorController : MonoBehaviour
{
    private TamaController _currentTama;
    private float _currentTamaCount = 0;
    [SerializeField] private float tamaSpawnSeconds = 1f;
    [SerializeField] private float cooldownSeconds = 1f;
    [SerializeField] private Transform tamaSpawnTransform;
    [SerializeField] private float tamaSpawnVel = 5f;

    private void Update()
    {
        if (_currentTama == null)
        {
            if (_currentTamaCount > 0)
                _currentTamaCount -= Time.deltaTime;
            return;
        }

        _currentTamaCount += Time.deltaTime;
        if (_currentTamaCount > tamaSpawnSeconds)
        {
            _currentTamaCount = cooldownSeconds;
            _currentTama.Show(tamaSpawnTransform.position, tamaSpawnTransform.rotation * Vector2.up * tamaSpawnVel);
            _currentTama = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_currentTamaCount > 0)
            return;
        if (!other.CompareTag("Tama"))
            return;
        if (_currentTama != null)
            return;
        _currentTamaCount = 0;
        
        _currentTama = other.GetComponentInParent<TamaController>();
        _currentTama.Shrink();
    }
}
