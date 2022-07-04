using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    private bool music;
    private bool sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = true;
        music = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicOn()
    {
        music = true;
    }

    public void MusicOff()
    {
        music = false;
    }

    public void SoundOn()
    {
        sound = true;
    }

    public void SoundOff()
    {
        sound = false;
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
