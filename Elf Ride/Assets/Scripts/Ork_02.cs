using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ork_02 : MonoBehaviour
{
    public float moveSpeed;

    public Transform rightPoint;
    public Transform leftPoint;

    private Rigidbody2D rb;

    private bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movingRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight && transform.position.x > rightPoint.position.x)
        {
            movingRight = false;
        }

        else if(!movingRight && transform.position.x < leftPoint.position.x)
        {
            movingRight = true;
        }

        if(movingRight)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0f);
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
        }

        else if(!movingRight)
        {
            transform.localScale = new Vector3(-0.25f, 0.25f, 0f);
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
        }
    }
}
