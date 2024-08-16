using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private const int _numberOfLevel = 3;
    [SerializeField] private FinishPlayer[] _finishPlayers;

    private int _curentLevel = 1;

    private void Update()
    {
        if (AreAllPlayersFinished() || Input.GetKeyDown(KeyCode.N))
        {
            NextLevel();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void NextLevel()
    {
        _curentLevel += 1;
        if (_curentLevel <= _numberOfLevel)
        {
            SceneManager.LoadScene("Level" + _curentLevel);
        }
        {
            RestartLevel();
        }
    }

    private bool AreAllPlayersFinished()
    {
        if (_finishPlayers != null && _finishPlayers.Length > 0)
        {
            foreach (FinishPlayer finishPlayer in _finishPlayers)
            {
                if (finishPlayer.IsFinished == false)
                    return false;
            }
            return true;
        }
        else
            return false;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
