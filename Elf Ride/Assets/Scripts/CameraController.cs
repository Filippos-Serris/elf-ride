using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    //private List<float> maxX = new List<float>() {268,268,378,0,0,0,0,0,0,0,0,0,0,0,0,0};
    public float maxX;

    [HideInInspector]
    public float posY;

    public GameObject target;
    public float followAhead;
    public float smoothy;

    private Vector3 targetPositon;

    void Start()
    {
        posY = 0f;
    }

    void Update()
    {
        targetPositon = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

        if (target.transform.localScale.x > 0f)  // if Player looks right
        {
            targetPositon = new Vector3(targetPositon.x + followAhead, targetPositon.y, targetPositon.z);    // camera showing some space ahead from the right side
        }

        else
        {
            targetPositon = new Vector3(targetPositon.x - followAhead, targetPositon.y, targetPositon.z);
        }

        //transform.position = targetPositon;    // after setting the position to a value set the camera lookin to it

        transform.position = Vector3.Lerp(transform.position, targetPositon, smoothy * Time.deltaTime);

        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), Mathf.Clamp(transform.position.z, minZ, maxZ));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0f, maxX), Mathf.Clamp(transform.position.y, posY, posY), Mathf.Clamp(transform.position.z, -10f, -10f));
    }
}
