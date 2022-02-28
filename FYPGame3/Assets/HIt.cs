using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIt : MonoBehaviour
{
    public GameObject scorePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vehicles")
        {

            GameObject scoreText = Instantiate(scorePrefab, transform.position, Quaternion.LookRotation(-transform.forward)) as GameObject;
            scoreText.GetComponent<TextMesh>().text = "-10";
            Debug.Log("HI");
        }
    }
}

