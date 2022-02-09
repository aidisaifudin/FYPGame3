using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
    public void Start()
    {
        PlayerPrefs.GetInt("earnings", Earnings.earnings);
        PlayerPrefs.GetString("time", DigitalClock.timer);
        Time.timeScale = 1;
    }
    public void BackToMainMenu()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
  

    public void MainGame()
    {
        SceneManager.LoadScene("MainGame");
        PlayerPrefs.GetInt("earnings", Earnings.earnings);
        PlayerPrefs.GetString("time", DigitalClock.timer);
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Settings()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
