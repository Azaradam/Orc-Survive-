using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    public bool isPaused = false;
    public AudioSource bgm;

    public void ArMode( )
    {
        SceneManager.LoadScene(1);
    }
    public void NormalMode()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        if(isPaused)
        {
            Time.timeScale = 1;
            isPaused = !isPaused;
            bgm.Play();
        } else
        {
            Time.timeScale = 0;
            isPaused = !isPaused;
            bgm.Pause();
        }
    }
}
