using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TriggerTutorial : MonoBehaviour
{
    public GameObject panel;
    public GameObject boxCollider;
    public TMP_Text message1;
    public TMP_Text message2;
    public TMP_Text message3;
    public TMP_Text message4;
    public TMP_Text message5;
    public TMP_Text message6;
    public TMP_Text message7;
    public TMP_Text message8;
    public TMP_Text message9;
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
            panel.SetActive(true);
            Destroy(boxCollider);
            Time.timeScale = 0;

            switch (SetLanguage.languageIndex)
            {
                case 0: // Bahasa
                    message1.text = "Selamat datang ngentot";
                    message2.text = "Dont die man";
                    message3.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message4.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message5.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message6.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message7.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message8.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message9.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    break;
                case 1: // English
                    message1.text = "Hi welcome back bitch";
                    message2.text = "Mampus lu anjing";
                    message3.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message4.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message5.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message6.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message7.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message8.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    message9.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                    break;
            }

        }
        
    }

    
    public void EndTutorial()
    {
        SceneManager.LoadScene("MainGame");
    }
}
