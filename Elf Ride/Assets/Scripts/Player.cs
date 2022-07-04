using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public GameObject destroyEnemyBox;

    private LevelManager levelManager;

    public float moveSpeed;
    private float activeMoveSpeed;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRad;
    public LayerMask isGround;
    private bool grounded;

    [HideInInspector]
    public Vector3 respawnPoint;
    private float directionX;

    private bool onPlatform;
    public float onPlatformSpeed;

    public AudioSource jumpSound;

    private bool doorPassed;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        levelManager = FindObjectOfType<LevelManager>();

        respawnPoint = transform.position;

        activeMoveSpeed = moveSpeed;

        doorPassed = false;
    }
	
	void Update ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRad, isGround);

        directionX = CrossPlatformInputManager.GetAxis("Horizontal");

        if(onPlatform)
        {
            activeMoveSpeed = moveSpeed * onPlatformSpeed;
        }

        else
        {
            activeMoveSpeed = moveSpeed;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Force);
            jumpSound.Play();
            //Jump();
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", grounded);

        if(rb.velocity.y<0)
        {
            destroyEnemyBox.SetActive(true);
        }

        else
        {
            destroyEnemyBox.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX * activeMoveSpeed, rb.velocity.y);
    }

    public void Right()
    {
        transform.localScale = new Vector3(0.25f, 0.25f, 0f);
        //rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
    }

    public void Left()
    {
        transform.localScale = new Vector3(-0.25f, 0.25f, 0f);
        //rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Door") && !doorPassed)
        {
            doorPassed = true;
            levelManager.NextLevel();
        }

        if(collision.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = collision.gameObject.transform.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = collision.transform;
            onPlatform = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = null;
            onPlatform = false;

        }
    }

    private void OnEnable()
    {
        transform.parent = null;
        onPlatform = false;
    }
}
