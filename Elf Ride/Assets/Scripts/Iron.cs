using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iron : MonoBehaviour
{
    private Renderer ren;
    private Rigidbody2D rb;

    public Vector3 ironPos;
    public Quaternion ironRot;

	// Use this for initialization
	void Start ()
    {
        ren = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();

        ren.enabled = false;
        rb.freezeRotation = true;

        ironPos = transform.position;
        ironRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.freezeRotation = false;
            ren.enabled = true;
            rb.isKinematic = false;
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !collision.gameObject.name.Equals("Path (3)"))
        {
            yield return new WaitForSecondsRealtime(2);

            Destroy(this.gameObject);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = true;
            rb.freezeRotation = true;
            rb.velocity = Vector2.zero;

            ren.enabled = false;

            transform.position = ironPos;
            transform.rotation = ironRot;
        }
    }
}
