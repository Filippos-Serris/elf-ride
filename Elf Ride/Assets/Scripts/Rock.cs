using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;

    public float endPoint;

    private bool canMove;

    public GameObject player;

    private bool activated;

    public AudioSource rockSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        activated = false;
    }

    void Update()
    {
        if (transform.position.x <= endPoint /*|| transform.position.x < player.transform.position.x-20*/)
        {
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX;

            rb.isKinematic = true;
            gameObject.SetActive(false);
            rockSound.Stop();
        }

        if(canMove)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y,0f);
        }

        if(activated)
        {
            rb.isKinematic = true;
            activated = false;
        }
    }

    private void OnBecameVisible()
    {
        rb.isKinematic = false;
        canMove = true;
        rockSound.Play();
    }

    private void OnEnable()
    {
        rockSound.Stop();
        canMove = false;
        activated = true;
    }
}
