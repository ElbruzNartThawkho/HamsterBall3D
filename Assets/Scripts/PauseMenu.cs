using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void StopGame(bool stop)
    {
        if (stop)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void MenuBack()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    
}
