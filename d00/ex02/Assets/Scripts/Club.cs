using UnityEngine;

public class Club : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float _powerPerSec;
    private Renderer _renderer;
    private float _timerKeyDown = 0;
    private bool _spaceKeyUp;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!ball.InMove && !_spaceKeyUp)
        {
            if (_renderer.enabled == false)
            {
                StartNewShoot();
            }
            
            if (Input.GetKey(KeyCode.Space))
            {
                _timerKeyDown += _powerPerSec * Time.deltaTime;
                transform.Translate(ball.Bounced * Time.deltaTime * Vector3.down);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                _spaceKeyUp = true;
            }
        } else if (_spaceKeyUp)
        {
            transform.Translate(ball.Bounced * Vector3.up * Time.deltaTime);
            if (ball.Bounced * (transform.position.x - ball.transform.position.x) <= 0.5)
            {
                ball.MoveBall(_timerKeyDown);
                _timerKeyDown = 0;
                _spaceKeyUp = false;
            }
        } else
        {
            _renderer.enabled = false;
        }
    }

    private void StartNewShoot()
    {
        transform.position = new Vector3(ball.transform.position.x + 1.0f * ball.Bounced, 2.25f, 0);
        _renderer.enabled = true;
    }
}
