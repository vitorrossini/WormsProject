using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator transition;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip start;
    [SerializeField] GameObject rules;
    private IEnumerator WaitForSceneLoad()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2);
       
        SceneManager.LoadScene("Chicken");
    }

        public void PlayGame()
    {
        audioSource.PlayOneShot(start);
        StartCoroutine(WaitForSceneLoad());
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Object.DontDestroyOnLoad(start);
    }

        public void Rules()
        {
            rules.SetActive(true);
        }


    public void QuitButton()
    {
        Application.Quit();
    }


}



