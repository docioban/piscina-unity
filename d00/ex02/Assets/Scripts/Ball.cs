using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool InMove { get; private set; }
    public int Bounced { get; private set; } = 1;

    [SerializeField] private Transform _minTransform;
    [SerializeField] private Transform _maxTransform;
    [SerializeField] private Transform _holePosition;
    [SerializeField] private float _smoothMove;
    private float _minX;
    private float _maxX;
    private float _power = 0;
    private int _score = -15;
    private Vector3 _initialPosition;
    private const int ScoreStep = 5;

    void Start()
    {
        Debug.Log("Your score is " + _score);
        _initialPosition = transform.position;
        _minX = _minTransform.position.x + _minTransform.localScale.x / 2 + transform.localScale.x / 2;
        _maxX = _maxTransform.position.x - _maxTransform.localScale.x / 2 - transform.localScale.x / 2;
    }

    void Update()
    {
        if (_power > 0)
        {
            InMove = true;
            transform.Translate(Bounced * _power * Time.deltaTime * Vector3.left);

            _power -= _smoothMove;
        } else
        {
            InMove = false;
            Bounced = _holePosition.position.x > transform.position.x ? -1 : 1;
        }

        if (transform.position.x <= _minX || transform.position.x >= _maxX)
        {
            Bounced *= -1;
        }

        if (transform.position.y <= 0)
        {
            ScoreGoal();
        }
        
    }

    public void MoveBall(float power)
    {
        _power = power;
        _score += ScoreStep;
        Debug.Log("Score = " + _score);
    }

    private void ScoreGoal()
    {
        if (_score > 0)
        {
            Debug.Log("Lost!");
        } else
        {
            Debug.Log("Win!");
        }
        SetInitialVariable();
    }

    private void SetInitialVariable()
    {
        transform.position = _initialPosition;
        Bounced = 1;
        _power = 0;
        _score = -15;
    }
}
