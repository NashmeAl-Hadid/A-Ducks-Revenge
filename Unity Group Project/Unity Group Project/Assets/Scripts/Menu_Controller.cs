using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
    public void PlayMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu");
        Time.timeScale = 1f;
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(sceneName: "Level01");
        Time.timeScale = 1f;
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene(sceneName: "Level02");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
