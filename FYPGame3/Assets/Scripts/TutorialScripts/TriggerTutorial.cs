using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTutorial : MonoBehaviour
{
    public GameObject panel;
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
            panel.SetActive(true);
            Destroy(boxCollider);
            Time.timeScale = 0;
           
        }
        
    }

    
    public void EndTutorial()
    {
        SceneManager.LoadScene("MainGame");
    }
}
