using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator transition;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip start;
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
        Object.DontDestroyOnLoad(start);
    }

    


    public void QuitButton()
    {
        Application.Quit();
    }


}



