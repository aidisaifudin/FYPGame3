using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public GameObject pausePanelEnglish;
    public GameObject pausePanelBahasa;

    public void Start()
    {
        Time.timeScale = 1;
        pausePanelEnglish.SetActive(false);
        pausePanelBahasa.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        switch (SetLanguage.languageIndex)
        {
            case 0: // Bahasa

                pausePanelBahasa.SetActive(true);

                break;
            case 1: // English

                pausePanelEnglish.SetActive(true);
                break;
        }

       
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanelBahasa.SetActive(false);
        pausePanelEnglish.SetActive(false);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    
    
}
