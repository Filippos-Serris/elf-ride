using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public GameObject movingObject;

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed;

    private Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = endPoint.position;       
    }

    // Update is called once per frame
    void Update()
    {
        movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (movingObject.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
        }

        if (movingObject.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }
    }
}
