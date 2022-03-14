using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTutorial : MonoBehaviour
{
    public GameObject summary;
    public GameObject skipPanelEnglish;
    public GameObject skipPanelBahasa;

    public void TimePause()
    {
        switch (SetLanguage.languageIndex)
        {
            case 0: // Bahasa

                skipPanelBahasa.SetActive(true);

                break;
            case 1: // English

                skipPanelEnglish.SetActive(true);
                break;
        }
        Time.timeScale = 0;
    }

    public void Resume()
    {
        switch (SetLanguage.languageIndex)
        {
            case 0: // Bahasa

                skipPanelBahasa.SetActive(false);

                break;
            case 1: // English

                skipPanelEnglish.SetActive(false);
                break;
        }
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
