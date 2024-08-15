using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player[] _players;
    private Vector3 offset = new(0, 0, -10f);
    private Vector3 velocity = Vector3.zero;
    private readonly float _smoothTime = 0.25f;
    private int _indexPlayer;

    private void Start()
    {
        ActivatePlayer(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _indexPlayer != 0)
        {
            ActivatePlayer(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _indexPlayer != 1)
        {
            ActivatePlayer(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && _indexPlayer != 2)
        {
            ActivatePlayer(2);
        }

        MoveFocus(_players[_indexPlayer].transform.position);
    }

    private void ActivatePlayer(int index)
    {
        if (index >= 0 && index < _players.Length)
        {
            _players[_indexPlayer].Desactivate();
            _indexPlayer = index;
            _players[_indexPlayer].Activate();
        }
    }

    private void MoveFocus(Vector3 position)
    {
        transform.position = Vector3.SmoothDamp(transform.position, position + offset, ref velocity, _smoothTime);
    }
}
