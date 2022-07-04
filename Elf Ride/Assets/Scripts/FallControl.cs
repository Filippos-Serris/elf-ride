using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallControl : MonoBehaviour
{
    public GameObject player;

    public GameObject platform1;
    private Vector3 pos1;

    public GameObject platform2;
    private Vector3 pos2;

    public GameObject platform3;
    private Vector3 pos3;

    public GameObject platform4;
    private Vector3 pos4;

    public GameObject platform5;
    private Vector3 pos5;

    public GameObject platform6;
    private Vector3 pos6;



    // Start is called before the first frame update
    void Start()
    {
        pos1 = platform1.transform.position;
        pos2 = platform2.transform.position;
        pos3 = platform3.transform.position;
        pos4 = platform4.transform.position;
        pos5 = platform5.transform.position;
        pos6 = platform6.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x<23)
        {
            platform1.SetActive(true);
            platform1.transform.position = pos1;

            platform2.SetActive(true);
            platform2.transform.position = pos2;

            platform3.SetActive(true);
            platform3.transform.position = pos3;

            platform4.SetActive(true);
            platform4.transform.position = pos4;

            platform5.SetActive(true);
            platform5.transform.position = pos5;

            platform6.SetActive(true);
            platform6.transform.position = pos6;
        }
        
    }
}
