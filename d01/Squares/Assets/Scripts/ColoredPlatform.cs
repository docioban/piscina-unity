using UnityEngine;

public class ColoredPlatform : MonoBehaviour
{
    [SerializeField] private LevelController _levelController;
    [SerializeField] private PlayerColor _platformColor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            if (player.Color() != _platformColor)
            {
                _levelController.RestartLevel();
            }
        }
    }
}
