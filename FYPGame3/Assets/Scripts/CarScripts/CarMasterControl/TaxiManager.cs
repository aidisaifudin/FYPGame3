using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaxiManager : MonoBehaviour
{
    public GameObject passenger;
    public static bool passengerInTaxi;
    public GameObject destination;
    public static bool destinationReached;
    //public GameObject reachedPassenger;
    public GameObject summary;
    //public GameObject arrow;
    public float currentTime = 300f;
    public float startingTime = 300f;
    //[SerializeField] Text countdownText;
    public GameObject hired;
    public GameObject free;
    public GameObject closeBtn;
    
    public static bool findingPassenger;

    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        destination = GameObject.FindGameObjectWithTag("Destination");
        passengerInTaxi = false;
        destinationReached = false;
        //summary.SetActive(false);
        hired.SetActive(false);
        free.SetActive(true);
        findingPassenger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (passengerInTaxi)
        {
            Destroy(passenger);
        }

        if (destinationReached)
        {
            Destroy(destination);
        }

        currentTime = currentTime - 1 * Time.deltaTime;
        if(currentTime <= 0)
        {
            currentTime = 0f;
            Time.timeScale = 0;
            summary.SetActive(true);
            if(Earnings.earned <= Earnings.losses)
            {
                Earnings.instance.DriveBetter();
                
            }
            else
            {
                Earnings.instance.GoodJob();
                

            }
        }

        if (Earnings.earnings <= 0)
        {
            Earnings.earnings = 0;
            Time.timeScale = 0;
            summary.SetActive(true);
            Earnings.instance.DriveBetter();
            closeBtn.gameObject.SetActive(false);
            
            
        }
        
        //if (free.SetActive = true)
        //{
        //    findingPassenger = true;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Passenger")
        {
            passengerInTaxi = true;
            Destroy(other.gameObject);
            hired.SetActive(true);
            free.SetActive(false);
        }
        else if (other.gameObject.tag == "Destination" && passengerInTaxi)
        {
            destinationReached = true;
            passengerInTaxi = false;
            hired.SetActive(false);
            free.SetActive(true);
            Earnings.instance.EarnMoney();
            Destroy(other.gameObject);
            RandomPassenger.instance.SpawnPassenger();
        
        }
    }
}
