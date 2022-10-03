using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static bool gameIsPaused = false;

    [SerializeField] public GameObject player1MenuUI;
    [SerializeField] public GameObject player2MenuUI;



    void Update()
    {
        PauseMenu.gameIsPaused = false;
    }

   
    public void Player1Wins()
    {
        player1MenuUI.SetActive(true);
        
        
    }

    public void Player2Wins()
    {
        player2MenuUI.SetActive(true);

    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("chicken");
    }
}
