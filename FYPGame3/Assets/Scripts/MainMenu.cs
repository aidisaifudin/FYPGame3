using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MainGame()
    {
        SceneManager.LoadScene("Testroad");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void Settings()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
