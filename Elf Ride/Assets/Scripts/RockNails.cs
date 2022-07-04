using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNails : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public float dropSpeed;

    public bool enable;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        enable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enable)
        {
            enable = false;

            rb.velocity = Vector3.zero;
            rb.gravityScale = 0f;

            anim.SetBool("hitObject", false);
            anim.SetBool("onCamera", false);   
        }
    }

    private void OnBecameVisible()
    {
        anim.SetBool("onCamera", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("onCamera", false);
            rb.gravityScale = dropSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine("CoFade");   
        }
    }

    private IEnumerator CoFade()
    {
        anim.SetBool("hitObject", true);

        yield return new WaitForSeconds(1.2f);

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        enable = true;
    }

    
}
