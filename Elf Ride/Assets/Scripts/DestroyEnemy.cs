using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject enemyDeathExplosion;
    public float bounceForce;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            Instantiate(enemyDeathExplosion, collision.transform.position, collision.transform.rotation);
            rb.velocity = new Vector3(rb.velocity.x, bounceForce, 0f);
        }
    }
}
