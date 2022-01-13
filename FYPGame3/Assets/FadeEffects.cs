using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffects : MonoBehaviour
{
    public Text text;

    public float fadeSpeed = 5.0f;
    public bool entrance;
    public GameObject canvas;

    void Awake()
    {
        
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
            text.color = Color.Lerp(text.color, Color.white, fadeSpeed * Time.deltaTime);
 
        }

        if (!entrance)
        {
            text.color = Color.Lerp(text.color, Color.clear, fadeSpeed * Time.deltaTime);
            
        }
    }
}
