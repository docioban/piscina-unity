using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float direction;
    private bool selectedPlayer;
    private Vector2 finishOfset = new Vector2(0.2f, 0.2f);

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float jumpPower;
    [SerializeField] private float speed;
    [SerializeField] private Transform finishPoint;


    // Update is called once per frame
    void Update()
    {
        if (selectedPlayer)
        {
            GetDirection();

            Jump();

            rb.velocity = new Vector2(direction * speed, rb.velocity.y);


        }
    }

    public void Activate()
    {
        selectedPlayer = true;
    }

    public void Desactivate()
    {
        selectedPlayer = false;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private bool IsGrounded()
    {
        //groundCheck.position.x - groundCheck.lossyScale.x;
        //groundCheck.position.y - groundCheck.lossyScale.y;


        ////return true;
        //Debug.Log("position: " + groundCheck.position);
        //Debug.Log("Scale: " + groundCheck.lossyScale);
        //Debug.Log("from" + (groundCheck.position - groundCheck.lossyScale / 2) + ", To: " + (groundCheck.position + groundCheck.lossyScale / 2));
        return Physics2D.OverlapArea(groundCheck.position - groundCheck.lossyScale / 2, groundCheck.position + groundCheck.lossyScale / 2, groundLayer);
        //return Physics2D.OverlapBox(transform.position, transform.localScale, 0, groundLayer);
        
    }

    private void GetDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            direction = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            direction = 1;
        else
            direction = 0;
    }

    private void CheckFinish()
    {
        //transform.position.Equals();
        //if (transform.position > finishPoint.position )
        //{

        //}
    }
}
