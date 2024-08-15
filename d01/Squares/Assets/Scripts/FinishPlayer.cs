using UnityEngine;

public class FinishPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;

    public bool IsFinished { get; private set; }
    private readonly float _threshold = 0.2f;

    private void Update()
    {
        if (IsFinishedLevel())
            IsFinished = true;
        else
            IsFinished = false;
    }

    private bool IsFinishedLevel()
    {
        float distance = Vector3.Distance(transform.position, playerPosition.position);

        return distance <= _threshold;
    }
}
