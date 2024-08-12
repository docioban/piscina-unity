using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField] private Pipe _pipe1;
    [SerializeField] private Pipe _pipe2;
    private Vector3 _initialPosition;
    private const float gravityEarth = 9.8f;
    private float _gravitySpeed;
    private float _rotateSpeed;
    private float _timePassed = 0;
    private bool _gameOver = false;
    private bool _menu = false;

    void Start()
    {
        _initialPosition = transform.position;
        _gravitySpeed = gravityEarth;
        _rotateSpeed = 40;
    }

    void Update()
    {
        if (!_gameOver)
        {
            if (_gravitySpeed <= gravityEarth)
                _gravitySpeed += 0.5f;

            if (transform.position.y > -6.5)
                Move();
            else
                FinishGame();

            if (PipeTouch())
                FinishGame();

            _timePassed += Time.deltaTime;
        } else
        {
            if (!_menu)
            {
                ShowResultats();
                _gameOver = false;
                _menu = true;
            } else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

    }

    private bool PipeTouch()
    {
        return _pipe1.BirdTouch(transform.position.y) || _pipe2.BirdTouch(transform.position.y);
    }

    private void Move()
    {
        transform.Translate(_gravitySpeed * Vector3.down * Time.deltaTime, Space.World);
        transform.Rotate(-_rotateSpeed * Vector3.forward * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        _gravitySpeed = -15f;
        transform.rotation = Quaternion.Euler(0, 0, 30);
    }

    private void FinishGame()
    {
        _gameOver = true;
        _pipe1.FinishGame();
        _pipe2.FinishGame();
    }

    private void ShowResultats()
    {
        Debug.Log("Score: " + _pipe1.Score);
        Debug.Log("Time: " + Mathf.RoundToInt(_timePassed) + "s");
    }
}
