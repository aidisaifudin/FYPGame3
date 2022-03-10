using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TriggerTutorial : MonoBehaviour
{
    public GameObject panelEnglish;
    public GameObject panelBahasa;
    public GameObject boxCollider;
   
    public bool triggerHit;

    public void Start()
    {
        triggerHit = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            triggerHit = true;
            
            Destroy(boxCollider);
            Time.timeScale = 0;

            switch (SetLanguage.languageIndex)
            {
                case 0: // Bahasa
                    
                    panelBahasa.SetActive(true);
               
                    break;
                case 1: // English
                    
                    panelEnglish.SetActive(true);
                    break;
            }

        }

        

    }

    
    public void EndTutorial()
    {
        SceneManager.LoadScene("MainGame");
    }
}
