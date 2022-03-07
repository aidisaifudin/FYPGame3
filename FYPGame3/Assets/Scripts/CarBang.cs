using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarBang : MonoBehaviour

{
    public GameObject scorePrefab;
    public GameObject scorePrefab1;
    
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
        if (other.gameObject.layer == 9)
        {
            if(Earnings.activateInsurance == true)
            {
                Debug.Log("It hit");
                Earnings.instance.LoseMoney(); 
                GameObject scoreText1 = Instantiate(scorePrefab1, transform.position, transform.rotation) as GameObject;
                scoreText1.transform.Rotate(0f, 180f, 0f);
                Destroy(scoreText1, 1);
                scoreText1.GetComponent<TextMesh>().text = "-5";

            }
            else if(Earnings.activateInsurance == false)
            {
                Debug.Log("It hit");
                Earnings.instance.LoseMoreMoney();
                GameObject scoreText = Instantiate(scorePrefab, transform.position,transform.rotation) as GameObject;
                scoreText.transform.Rotate(0f, 180f, 0f);
                Destroy(scoreText, 1);
                scoreText.GetComponent<TextMesh>().text = "-10";
            }
        }
    }
}
