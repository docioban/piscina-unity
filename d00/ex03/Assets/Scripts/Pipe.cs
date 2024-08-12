using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Transform _birdBody;
    private Vector3 initialPosition;
    private float _speed;
    private float _rightBirdX;
    private float _leftBirdX;
    private bool _finishedGame = false;
    public int Score { get; private set; }

    void Start()
    {
        initialPosition = transform.position;
        _speed = 10;
        _rightBirdX = _birdBody.position.x + _birdBody.localScale.x / 2 + transform.localScale.x / 2;
        _leftBirdX = _birdBody.position.x - _birdBody.localScale.x / 2 - transform.localScale.x / 2;
        Debug.Log("Right Position x = " + _rightBirdX);
        Debug.Log("Left Position x = " + _leftBirdX);
    }

    void Update()
    {
        if (!_finishedGame)
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.left);
            if (transform.position.x < -20)
                RestartPipe();
        }
    }

    private void RestartPipe()
    {
        transform.position = initialPosition;
        Score++;
        if (_speed < 30)
            _speed += 1;
    }

    public void FinishGame()
    {
        _finishedGame = true;
    }

    public bool BirdTouch(float birdPositionY)
    {
        if (transform.position.x > _rightBirdX || transform.position.x < _leftBirdX)
            return false;

        if ((birdPositionY + _birdBody.localScale.y / 2 < transform.position.y - transform.localScale.y / 2
            && birdPositionY - _birdBody.localScale.y / 2 < transform.position.y + transform.localScale.y / 2)
            ||
            (birdPositionY + _birdBody.localScale.y / 2 > transform.position.y - transform.localScale.y / 2
            && birdPositionY - _birdBody.localScale.y / 2 > transform.position.y + transform.localScale.y / 2))
        {
            return false;
        }
        return true;
    }
}
