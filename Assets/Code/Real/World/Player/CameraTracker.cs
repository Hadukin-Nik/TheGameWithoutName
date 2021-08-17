using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _trackerPosition;
    void Start()
    {
        _trackerPosition = transform.position - _player.position;
    }

    
    void Update()
    {
        transform.position = _player.position + _trackerPosition;
    }
}
