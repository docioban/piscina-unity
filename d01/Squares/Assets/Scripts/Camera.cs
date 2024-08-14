using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Player[] Players;
    private Vector3 offset = new Vector3(0, 0, -10f);
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.25f;
    private int indexPlayer;

    private void Start()
    {
        ActivatePlayer(0);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && indexPlayer != 0)
        {
            ActivatePlayer(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && indexPlayer != 1)
        {
            ActivatePlayer(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && indexPlayer != 2)
        {
            ActivatePlayer(2);
        }

        MoveFocus(Players[indexPlayer].transform.position);
    }

    private void ActivatePlayer(int index)
    {
        if (index >= 0 && index < Players.Length)
        {
            Players[indexPlayer].Desactivate();
            indexPlayer = index;
            Players[indexPlayer].Activate();
        }
    }

    private void MoveFocus(Vector3 position)
    {
        transform.position = Vector3.SmoothDamp(transform.position, position + offset, ref velocity, smoothTime);
    }
}
