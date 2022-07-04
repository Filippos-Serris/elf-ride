using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI time;
    public float timer; 

    // Start is called before the first frame update
    void Start()
    {
        time.text=": " + timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        time.text = ": " + Mathf.Round(timer);
    }
}
