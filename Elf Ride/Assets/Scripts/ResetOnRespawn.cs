using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnRespawn : MonoBehaviour
{
    private Vector3 objectPos;
    private Quaternion objectRot;
    private Vector3 objectScale;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        objectPos = transform.position;
        objectRot = transform.rotation;
        objectScale = transform.localScale;

        if(GetComponent<Rigidbody2D>() != null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObjectReset()
    {
        transform.position = objectPos;
        transform.rotation = objectRot;
        transform.localScale = objectScale;

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
