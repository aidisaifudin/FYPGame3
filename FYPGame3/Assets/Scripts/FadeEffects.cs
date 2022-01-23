using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeEffects : MonoBehaviour
{
    public TextMeshProUGUI textCredits;

    public float fadeSpeed = 5.0f;
    public bool entrance;
    public GameObject canvas;

    public void Start()
    {
        textCredits = FindObjectOfType<TextMeshProUGUI>();
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
            textCredits.color = Color.Lerp(textCredits.color, Color.white, fadeSpeed * Time.deltaTime);
 
        }

        if (!entrance)
        {
            textCredits.color = Color.Lerp(textCredits.color, Color.clear, fadeSpeed * Time.deltaTime);
            
        }
    }
}
