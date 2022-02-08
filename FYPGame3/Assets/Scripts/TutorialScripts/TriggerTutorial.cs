using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTutorial : MonoBehaviour
{
    public GameObject panel;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void EndTutorial()
    {
        SceneManager.LoadScene("MainGame");
    }
}