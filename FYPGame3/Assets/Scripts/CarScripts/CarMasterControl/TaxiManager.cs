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
    float currentTime = 0f;
    float startingTime = 300f;
    [SerializeField] Text countdownText;
    public GameObject hired;
    public GameObject free;
    public static bool findingPassenger;

    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        destination = GameObject.FindGameObjectWithTag("Destination");
        passengerInTaxi = false;
        destinationReached = false;
        summary.SetActive(false);
        hired.SetActive(false);
        free.SetActive(true);
        findingPassenger = true;

        currentTime = startingTime;
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
            Earnings.instance.EarnMoney();
            Destroy(other.gameObject);
            RandomPassenger.instance.SpawnPassenger();
            hired.SetActive(false);
            free.SetActive(true);
        }
    }
}
