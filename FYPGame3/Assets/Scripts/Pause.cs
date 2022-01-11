using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    public void Start()
    {
        pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
