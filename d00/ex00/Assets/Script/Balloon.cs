using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float XIncreaseSize = 0.01f;
    public float YIncreaseSize = 0.01f;
    public float Speed = 0.01f;
    private Vector3 initialVector;
    private Vector3 maximumVector;
    [SerializeField] public PowerTab powerTab;
    GameObject FinalTextWin;


    // Start is called before the first frame update
    void Start()
    {
        FinalTextWin = GameObject.FindGameObjectWithTag("Finish");
        FinalTextWin.SetActive(false);
        initialVector = transform.localScale;
        maximumVector = new Vector3(x: 0.5f, y: 0.5f, z: 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (powerTab.IsPossibleIncrease())
            {
                IncreaseBallon();
                powerTab.IncreaseTab();
                if (IsMaximumSize() == true)
                {
                    ExplodeBallon();
                }
            }
        }

        if (IsMinimumSize() == false)
        {
            DecreseBallon();
        }
    }

    void ExplodeBallon()
    {
        print("Exploded!!!!!");
        gameObject.SetActive(false);
        FinalTextWin.SetActive(true);
    }

    bool IsMinimumSize()
    {
        if (transform.localScale.x < initialVector.x || transform.localScale.y < initialVector.y)
        {
            return true;
        }
        return false;
    }

    bool IsMaximumSize()
    {
        if (transform.localScale.x > maximumVector.x || transform.localScale.y > maximumVector.y)
        {
            return true;
        }
        return false;
    }

    void IncreaseBallon()
    {
        Vector3 temp;
        temp = transform.localScale;
        temp.x += XIncreaseSize;
        temp.y += YIncreaseSize;
        transform.localScale = temp;
    }

    void DecreseBallon()
    {
        Vector3 temp;
        temp = transform.localScale;
        temp.x -= Speed * Time.deltaTime;
        temp.y -= Speed * Time.deltaTime;
        transform.localScale = temp;
    }
}
