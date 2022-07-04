using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    private CameraController cameraController;

    public GameObject doorToGo;

    public float maxX, posY;

    // Start is called before the first frame update
    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = doorToGo.transform.position;

            // set border of camera to maxX and posY
            cameraController.posY = posY;
            cameraController.maxX = maxX;
        }
    }
}
