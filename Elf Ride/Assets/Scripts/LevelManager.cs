using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int coinsOwned;
    private int coinsTotal;

    [HideInInspector]
    public TextMeshProUGUI tmp;

    public Player player;

    public float waitToRespawn;
    private bool respawning;
    public GameObject deathExplosion;

    public Image heart_1;
    public Image heart_2;
    public Image heart_3;

    public Sprite heartFull;
    public Sprite heartEmpty;

    public int maxHealth;
    private int healthCounter;

    public ParticleSystem par_01;
    public ParticleSystem par_02;
    public ParticleSystem par_03;
    public ParticleSystem par_04;
    public ParticleSystem par_05;

    private ResetOnRespawn[] objectsToReset;

    public AudioSource coinSound;
    public AudioSource levelMusic;

    public GameObject gameOverPanel;

    public GameObject menuPanel;
    public GameObject optionsPanel;
    public GameObject pausePanel;


    // Use this for initialization
    void Start ()
    {
        coinsOwned = 0;

        tmp.text = "Coins: " + coinsOwned.ToString();

        if (PlayerPrefs.HasKey("Coins"))
        {
            coinsTotal = PlayerPrefs.GetInt("Coins");
        }

        else
        {
            coinsTotal = 0;
        }

        if (PlayerPrefs.HasKey("Lives"))
        {
            //healthCounter = maxHealth;
            healthCounter = PlayerPrefs.GetInt("Lives");
            UpdateHearts();
        }

        else if(!PlayerPrefs.HasKey("Lives") || PlayerPrefs.GetInt("Lives")<=0)
        {
            healthCounter = maxHealth;
        }

        objectsToReset = FindObjectsOfType<ResetOnRespawn>();

        respawning = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
//----------------------------------------------------------------------------------
    public void Menu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MenuOK()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void MenuNo()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
//----------------------------------------------------------------------------------
    public void Pause()
    {
        if(Time.timeScale==0f)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }

        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
//----------------------------------------------------------------------------------
    public void Options()
    {
        optionsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OptionsOK()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void OptionsNo()
    {
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;
    }
//---------------------------------------------------------------------------------
    public void AddCoins(int coinToAdd)
    {
        coinsOwned += coinToAdd;

        tmp.text = "Coins: " + coinsOwned.ToString();

        coinSound.Play();
    }
//---------------------------------------------------------------------------------
    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo()
    {
        player.gameObject.SetActive(false);

        Instantiate(deathExplosion, player.transform.position, player.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        player.transform.position = player.respawnPoint;
        player.transform.localScale = new Vector3(0.25f, 0.25f, 0f);

        player.gameObject.SetActive(true);

        for(int i=0;i<objectsToReset.Length; i++)
        {
            if(objectsToReset[i].gameObject.activeSelf==true)
            {
                objectsToReset[i].gameObject.SetActive(false);
            }

            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ObjectReset();
        }
    }
//---------------------------------------------------------------------------------
    public void HurtPlayer(int damageTaken)
    {
        healthCounter -= damageTaken;
        UpdateHearts();
    }

    public void UpdateHearts()
    {
        switch(healthCounter)
        {
            case 3:
                heart_1.sprite = heartFull;
                heart_2.sprite = heartFull;
                heart_3.sprite = heartFull;
                break;

            case 2:
                heart_1.sprite = heartFull;
                heart_2.sprite = heartFull;
                heart_3.sprite = heartEmpty;
                break;

            case 1:
                heart_1.sprite = heartFull;
                heart_2.sprite = heartEmpty;
                heart_3.sprite = heartEmpty;
                break;

            case 0:
                if (SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 8 || SceneManager.GetActiveScene().buildIndex == 11 || SceneManager.GetActiveScene().buildIndex == 14)
                {
                    heart_1.sprite = heartEmpty;
                    heart_2.sprite = heartEmpty;
                    heart_3.sprite = heartEmpty;

                    PlayerPrefs.SetInt("Lives", maxHealth);

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }

                else
                {
                    heart_1.sprite = heartEmpty;
                    heart_2.sprite = heartEmpty;
                    heart_3.sprite = heartEmpty;

                    levelMusic.Stop();

                    gameOverPanel.SetActive(true);

                    StartCoroutine("CoGameOver");
                }

                break;
        }
    }

    private IEnumerator CoGameOver()
    {
        yield return new WaitForSeconds(6);

        PlayerPrefs.SetInt("Lives", maxHealth);

        if (SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 9 || SceneManager.GetActiveScene().buildIndex == 12 || SceneManager.GetActiveScene().buildIndex == 15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        else if (SceneManager.GetActiveScene().buildIndex == 7 || SceneManager.GetActiveScene().buildIndex == 10 || SceneManager.GetActiveScene().buildIndex == 13 || SceneManager.GetActiveScene().buildIndex == 16)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }

    public void Pay()
    {
        if (PlayerPrefs.HasKey("Coins") && PlayerPrefs.GetInt("Coins") >= 50)
        {
            coinsTotal -= 50;
            PlayerPrefs.SetInt("Coins", coinsTotal);

            healthCounter = 1;
            PlayerPrefs.SetInt("Lives", healthCounter);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
//---------------------------------------------------------------------------------
    public void NextLevel()
    {
        StartCoroutine("NextLevelCo");
    }

    private IEnumerator NextLevelCo()
    {
        par_01.gameObject.SetActive(true);
        par_02.gameObject.SetActive(true);
        par_03.gameObject.SetActive(true);
        par_04.gameObject.SetActive(true);
        par_05.gameObject.SetActive(true);

        coinsTotal += coinsOwned;

        PlayerPrefs.SetInt("Coins", coinsTotal);
        PlayerPrefs.SetInt("Lives", healthCounter);

        if(PlayerPrefs.GetInt("LevelsUnlocked") < SceneManager.GetActiveScene().buildIndex - 4)
        {
            PlayerPrefs.SetInt("LevelsUnlocked", SceneManager.GetActiveScene().buildIndex - 3);
        }

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}