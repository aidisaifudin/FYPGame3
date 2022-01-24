using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeEffects : MonoBehaviour
{
    public TMP_Text textCredits;

    
    
    public Animator animator;

    public void Start()
    {
        textCredits = FindObjectOfType<TMP_Text>();
      
    }

    void Update()
    {
       
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
           
            animator.SetBool("FadeIn", true);
            Debug.Log("hit");

        }
    }

    
}
