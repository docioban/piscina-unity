using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _speed = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _speed);
    }
}
