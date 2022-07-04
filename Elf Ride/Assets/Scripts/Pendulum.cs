using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private Rigidbody2D rb;

    public float leftPush;
    public float rightPush;

    public float velocityThres;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(this.name== "WoodenPendulum(R)")
        {
            rb.angularVelocity = velocityThres;
        }

        else if(this.name == "WoodenPendulum(L)")
        {
            rb.angularVelocity = -velocityThres;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.rotation.z > 0 && transform.rotation.z < rightPush && rb.angularVelocity > 0 && rb.angularVelocity < velocityThres)
        {
            rb.angularVelocity = velocityThres;
        }

        else if (transform.rotation.z < 0 && transform.rotation.z > leftPush && rb.angularVelocity < 0 && rb.angularVelocity > velocityThres * -1)
        {
            rb.angularVelocity = velocityThres * -1;
        }
    }


}
