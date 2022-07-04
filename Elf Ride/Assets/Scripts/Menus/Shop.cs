using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Coins"))
        {
            tmp.text = "Coins: " + PlayerPrefs.GetInt("Coins").ToString();
        }

        else
        {
            tmp.text += 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
