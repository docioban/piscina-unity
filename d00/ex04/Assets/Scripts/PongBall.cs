using UnityEngine;

public class PongBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _playerRight;
    [SerializeField] private Transform _playerLeft;
    [SerializeField] private Transform _topWall;
    [SerializeField] private Transform _bottomWall;
    private Vector3 _initialPosition;
    private int _directionX;
    private int _directionY;
    private bool _gameRun = true;
    private int _score1 = 0;
    private int _score2 = 0;

    void Start()
    {
        _directionX = Random.Range(0, 2) * 2 - 1;
        _directionY = Random.Range(0, 2) * 2 - 1;
        _initialPosition = transform.position;
    }

    void Update()
    {
        if (_gameRun)
        {
            TouchTopWall();
            TouchBottomWall();
            TouchRightPlayer();
            TouchLeftPlayer();
            TouchFinishLine();

            Move();
        } else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }
    }

    private void TouchFinishLine()
    {
        if (transform.position.x - transform.localScale.x * 0.5 > _playerRight.position.x + _playerRight.localScale.x * 0.5)
        {
            _score1++;
            Stop();
        }
        if (transform.position.x + transform.localScale.x * 0.5 < _playerLeft.position.x - _playerLeft.localScale.x * 0.5)
        {
            _score2++;
            Stop();
        }
    }

    private void TouchBottomWall()
    {
        if (transform.position.y - transform.localScale.y * 0.5 <= _bottomWall.position.y + _bottomWall.localScale.y * 0.5 && _directionY == -1)
            _directionY = 1;
    }

    private void TouchTopWall()
    {
        if (transform.position.y + transform.localScale.y * 0.5 >= _topWall.position.y - _topWall.localScale.y * 0.5 && _directionY == 1)
            _directionY = -1;
    }

    private void TouchRightPlayer()
    {
        if (transform.position.x + transform.localScale.x * 0.5 >= _playerRight.position.x - _playerRight.localScale.x * 0.5
                && transform.position.x + transform.localScale.x * 0.5 <= _playerRight.position.x + _playerRight.localScale.x * 0.5)
        {
            if (transform.position.y + transform.localScale.y * 0.5 > _playerRight.position.y - _playerRight.localScale.y * 0.5
                && transform.position.y - transform.localScale.y * 0.5 < _playerRight.position.y + _playerRight.localScale.y * 0.5 && _directionX == 1)
            {
                _directionX *= -1;
            }
        }
    }

    private void TouchLeftPlayer()
    {
        if (transform.position.x - transform.localScale.x * 0.5 <= _playerLeft.position.x + _playerLeft.localScale.x * 0.5 &&
                transform.position.x - transform.localScale.x * 0.5 >= _playerLeft.position.x - _playerLeft.localScale.x * 0.5)
        {
            if (transform.position.y + transform.localScale.y * 0.5 > _playerLeft.position.y - _playerLeft.localScale.y * 0.5
                && transform.position.y - transform.localScale.y * 0.5 < _playerLeft.position.y + _playerLeft.localScale.y * 0.5 && _directionX == -1)
            {
                _directionX = 1;
            }
        }
    }

    private void Move()
    {
        transform.Translate(_speed * new Vector3(_directionX, _directionY, 0) * Time.deltaTime);
    }

    private void Stop()
    {
        _directionX = 0;
        _directionY = 0;
        _gameRun = false;
        ShowResultat();
    }

    private void RestartGame()
    {
        _gameRun = true;
        transform.position = _initialPosition;
        _directionX = Random.Range(0, 2) * 2 - 1;
        _directionY = Random.Range(0, 2) * 2 - 1;
    }

    private void ShowResultat()
    {
        Debug.Log("Player 1: " + _score1 + " | Player 2: " + _score2);
    }
}
