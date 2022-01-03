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
        SceneManager.LoadScene("MainScene");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
