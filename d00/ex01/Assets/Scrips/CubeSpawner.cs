using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _objects;
    [SerializeField] private GameObject _finishLineObject;
    private List<GameObject> _generatedObjects = new List<GameObject>();
    private float Timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _generatedObjects.Add(Instantiate(_objects[Random.Range(0, 3)]));
    }

    // Update is called once per frame
    void Update()
    {
        GenerateNewObjects();
        FollowInputKey();
        DestroyObjectFromGenerated();
    }

    void GenerateNewObjects()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            _generatedObjects.Add(Instantiate(_objects[Random.Range(0, 3)]));
            Timer = 2f;
        }
    }

    void FollowInputKey()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DestroyObject("Blue");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            DestroyObject("Yello");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DestroyObject("Purple");
        }
    }

    void DestroyObject(string tag)
    {
        if (_generatedObjects.Exists(obj => obj.tag == tag))
        {
            List<GameObject> copyObjects = _generatedObjects.FindAll(obj => obj.tag == tag);
            GameObject maxObject = copyObjects[0];
            copyObjects.ForEach(obj =>
            {
                if (obj.transform.position.y < maxObject.transform.position.y)
                    maxObject = obj;
            });
            float precision = maxObject.transform.position.y - _finishLineObject.transform.position.y;
            Debug.Log("Precision: " + precision.ToString("F3"));
            Destroy(maxObject);
            _generatedObjects.Remove(maxObject);
        }
    }

    void DestroyObjectFromGenerated()
    {
        if (_generatedObjects.Exists(obj => obj.transform.position.y < -8.0f))
        {
            _generatedObjects.RemoveAll(obj =>
            {
                if (obj.transform.position.y < -8.0f)
                {
                    Destroy(obj); return true;
                }
                return false;
            });
        }
    }
}
