using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private const int _numberOfLevel = 3;

    [SerializeField] private FinishPlayer[] _finishPlayers;
    [SerializeField] private int _level;

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

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void NextLevel()
    {
        _level += 1;
        if (_level <= _numberOfLevel)
        {
            Debug.Log("Level" + _level);
            SceneManager.LoadScene("Level" + _level);
        }
        else
        {
            RestartLevel();
        }
    }

    private bool AreAllPlayersFinished()
    {
        if (_finishPlayers != null && _finishPlayers.Length > 0 && _finishPlayers[0] != null)
        {
            foreach (FinishPlayer finishPlayer in _finishPlayers)
            {
                if (finishPlayer.IsFinished == false)
                    return false;
            }
            Debug.Log("NextLeveL!");
            return true;
        }
        else
            return false;
    }
}
