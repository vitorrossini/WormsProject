using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator transition;
    private IEnumerator WaitForSceneLoad()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
       
        SceneManager.LoadScene("Chicken");
    }

        public void PlayGame()
    {

        StartCoroutine(WaitForSceneLoad());
    }


    public void QuitButton()
    {
        Application.Quit();
    }


}



