using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject rulesMenuUI;
    [SerializeField] AudioSource audioSource;

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (gameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        audioSource.Play();
        Cursor.visible = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        audioSource.Pause();
        Cursor.visible = true;


    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void Rules()
    {
        rulesMenuUI.SetActive(true);
    }

}
