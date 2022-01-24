using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeEffects : MonoBehaviour
{
    public TMP_Text textCredits;

    public float fadeSpeed = 5.0f;
    public bool entrance;
    public GameObject canvas;

    public void Start()
    {
        textCredits = FindObjectOfType<TMP_Text>();
    }

    void Update()
    {
        ColorChange();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            entrance = true;
        }
    }

   

    void ColorChange()
    {
        if (entrance)
        {
            textCredits.color = Color.Lerp(new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 1f), fadeSpeed * Time.deltaTime);
 
        }

        //if (!entrance)
        //{
        //    textCredits.color = Color.Lerp(textCredits.color, Color.clear, fadeSpeed * Time.deltaTime);
            
        //}
    }
}
