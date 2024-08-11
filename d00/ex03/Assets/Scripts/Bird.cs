using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private const float gravityEarth = 9.8f;
    private float _gravitySpeed;
    private float _rotateSpeed;

    void Start()
    {
        _gravitySpeed = gravityEarth;
        _rotateSpeed = 40;
    }

    void Update()
    {
        if (_gravitySpeed <= 9.8f)
        {
            _gravitySpeed += 0.5f;
        }
        if (transform.position.y > -9.5)
        {
            transform.Translate(_gravitySpeed * Vector3.down * Time.deltaTime, Space.World);
            transform.Rotate(-_rotateSpeed * Vector3.forward * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _gravitySpeed = -15f;
                transform.rotation = Quaternion.Euler(0, 0, 30);
            }
        }
    }
}
