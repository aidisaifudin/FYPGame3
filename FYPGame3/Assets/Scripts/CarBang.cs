using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarBang : MonoBehaviour
{
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
            if(Earnings.activateInsurance = true)
            {
                Debug.Log("It hit");
                Earnings.instance.LoseMoney();
            }
            else if(Earnings.activateInsurance = false)
            {
                Debug.Log("It hit");
                Earnings.instance.LoseMoreMoney();
            }
        }
    }
}
