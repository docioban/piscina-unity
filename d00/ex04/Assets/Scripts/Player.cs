using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _topWall;
    [SerializeField] private Transform _bottomWall;
    [SerializeField] private KeyCode _upButton;
    [SerializeField] private KeyCode _downButton;
    [SerializeField] private float _speed;

    void Update()
    {
        if (Input.GetKey(_upButton))
            if (transform.position.y + transform.localScale.y * 0.5 < _topWall.position.y - _topWall.localScale.y * 0.5)
                transform.Translate(_speed * Vector3.up * Time.deltaTime);

        if (Input.GetKey(_downButton))
            if (transform.position.y - transform.localScale.y * 0.5 > _bottomWall.position.y + _bottomWall.localScale.y * 0.5)
                transform.Translate(_speed * Vector3.down * Time.deltaTime);
    }
}
