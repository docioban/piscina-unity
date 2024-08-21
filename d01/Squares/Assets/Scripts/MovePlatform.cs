using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform _destinationPosition;
    [SerializeField] private float _speed;

    private Vector3 _initialPosition;
    private bool _goRight;

    private void Start()
    {
        _initialPosition = transform.position;
        _goRight = _initialPosition.x < _destinationPosition.position.x;
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * (_goRight ? Vector3.right : Vector3.left));

        if (_goRight && transform.position.x >= _destinationPosition.position.x)
            _goRight = false;
        else if (!_goRight && transform.position.x <= _initialPosition.x)
            _goRight = true;
    }
}
