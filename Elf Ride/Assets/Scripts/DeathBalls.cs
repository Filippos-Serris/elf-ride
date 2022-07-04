using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBalls : MonoBehaviour
{
    public GameObject ball;

    public float minX, maxX;
    public float waitingTime;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FallingBalls", 0f, waitingTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FallingBalls()
    {
        Instantiate(ball, new Vector3(Random.Range(minX, maxX + 1), 10f, 0f), Quaternion.identity);
    }
}
