using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    private int levelsUnlocked;

    public Button[] levelButtons;
    
    // Start is called before the first frame update
    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1);

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i+1 > levelsUnlocked)
            {
                levelButtons[i].interactable = false;
            }
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

    public void LevelToGo(string levelSelect)
    {
        SceneManager.LoadScene(levelSelect);
    }
}
