using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menus : MonoBehaviour
{
    //main menu
    public TextMeshProUGUI highscore;

    public void Start()
    {
        FindObjectOfType<AudioManager>().play("BackgroundMusic");

        var activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == "MainMenu")
        {
            highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
    }

    public void Update()
    {
        PauseMenu();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    //lose menu

    public GameObject loseMenu;

    public void LoseMenu()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    //pause menu

    public bool pauseMenuOn = false;
    public GameObject pauseMenu;

    public void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenuOn)
            {
                Resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                pauseMenuOn = true;
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseMenuOn = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
