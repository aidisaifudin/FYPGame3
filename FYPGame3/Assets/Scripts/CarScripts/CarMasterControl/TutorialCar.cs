using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCar : MonoBehaviour
{
    public GameObject passenger;
    public GameObject destination;
    public GameObject summary;
    public bool destinationReached;
    public GameObject tryAgainBtn;

    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        destination = GameObject.FindGameObjectWithTag("Destination");
        summary.SetActive(false);
        destinationReached = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (destinationReached)
        {
            summary.SetActive(true);
            Time.timeScale = 0;
            tryAgainBtn.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Passenger")
        {
            //passengerInTaxi = true;
            Destroy(other.gameObject);
            //arrow.SetActive(true);
        }
        else if (other.gameObject.tag == "Destination")
        {
            destinationReached = true;

            Earnings.instance.EarnMoney();
            Destroy(other.gameObject);
            //RandomPassenger.instance.SpawnPassenger();
            //arrow.SetActive(true);
        }
    }

    public void CloseSummary()
    {
        destinationReached = false;
        summary.SetActive(false);
        Debug.Log("Close Summary");
        Time.timeScale = 1;
        
    }

    public void RestartLevel()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Tutorial");
    }
}
