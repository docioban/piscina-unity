using UnityEngine;

public class PowerTab : MonoBehaviour
{
    private readonly float _minScaleY = 0.1f;
    private readonly float _maxScaleY = 8.0f;
    public float ScaleStepY = 1f;
    public float Speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMinimumY() == false)
        {
            DecreseTab();
        }
    }

    public void IncreaseTab()
    {
        Vector3 temp;
        temp = transform.localScale;
        temp.y += ScaleStepY;
        transform.localScale = temp;
    }

    private void DecreseTab()
    {
        Vector3 temp;
        temp = transform.localScale;
        temp.y -= Speed * Time.deltaTime;
        transform.localScale = temp;
    }

    bool IsMinimumY()
    {
        bool retVal = false;
        if (transform.localScale.y <= _minScaleY)
        {
            retVal = true;
        }
        return retVal;
    }

    public bool IsPossibleIncrease()
    {
        if (transform.localScale.y + ScaleStepY > _maxScaleY)
            return false;
        else
            return true;
    }
}
