using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerColor
{
    Red,
    Yellow,
    Blue
}

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _speed;
    [SerializeField] private PlayerColor _playerColor;

    private float _direction;
    private bool _selectedPlayer;
    private float _maxBottomPosition = -12f;

    private void Update()
    {
        if (transform.position.y < _maxBottomPosition)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (_selectedPlayer)
        {
            GetDirection();
            Jump();
            _rb.velocity = new Vector2(_direction * _speed, _rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlueMovementPlatform"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlueMovementPlatform"))
        {
            Invoke("UnparentObject", 0.1f);
        }
    }

    private void UnparentObject()
    {
        transform.SetParent(null);
    }

    public PlayerColor Color()
    {
        return _playerColor;
    }

    public void Activate()
    {
        _selectedPlayer = true;
    }

    public void Desactivate()
    {
        _selectedPlayer = false;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapArea(_groundCheck.position - _groundCheck.lossyScale / 2, _groundCheck.position + _groundCheck.lossyScale / 2);
    }

    private void GetDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            _direction = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            _direction = 1;
        else
            _direction = 0;
    }
}
