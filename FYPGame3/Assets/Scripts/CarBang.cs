using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarBang : MonoBehaviour

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
        if (other.gameObject.layer == 9)
        {
            if(Earnings.activateInsurance == true)
            {
                Debug.Log("It hit");
                Earnings.instance.LoseMoney(); 
                //GameObject scoreText = Instantiate(scorePrefab, transform.position, Quaternion.LookRotation(transform.forward)) as GameObject;
                //scoreText.GetComponent<TextMesh>().text = "-5";

            }
            else if(Earnings.activateInsurance == false)
            {
                Debug.Log("It hit");
                Earnings.instance.LoseMoreMoney();
               // GameObject scoreText = Instantiate(scorePrefab, transform.position, Quaternion.LookRotation(transform.forward)) as GameObject;
                //scoreText.GetComponent<TextMesh>().text = "-10";
            }
        }
    }
}
