using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ork_01 : MonoBehaviour
{
    public float moveSpeed;
    private bool canMove;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
        }
    }

    private void OnBecameVisible()
    {
        canMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        canMove = false;
    }
}
