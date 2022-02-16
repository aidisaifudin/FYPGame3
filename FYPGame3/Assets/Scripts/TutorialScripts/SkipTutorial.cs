using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTutorial : MonoBehaviour
{
    public GameObject summary;

   public void TimePause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void ChangeToGame()
    {
        SceneManager.LoadScene("MainGame");
        PlayerPrefs.DeleteAll();
    }

    public void CloseSummary()
    {
        summary.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("MainGame");
            PlayerPrefs.DeleteAll();
        }
    }
}
