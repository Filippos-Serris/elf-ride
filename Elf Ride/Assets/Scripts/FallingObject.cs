using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Rigidbody2D rb;

    public float waitSeconds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Fall");
        }

        if(collision.gameObject.CompareTag("Obstacle"))
        {
            rb.isKinematic = true;
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(waitSeconds);

        rb.isKinematic = false;
    }
}
