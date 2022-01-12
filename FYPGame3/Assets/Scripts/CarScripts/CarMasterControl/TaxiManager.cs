using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaxiManager : MonoBehaviour
{
    public GameObject passenger;
    public bool passengerInTaxi;
    public GameObject destination;
    public static bool destinationReached;
    //public GameObject reachedPassenger;
    public GameObject summary;
    //public GameObject arrow;
    float currentTime = 0f;
    float startingTime = 300f;
    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        destination = GameObject.FindGameObjectWithTag("Destination");
        passengerInTaxi = false;
        destinationReached = false;
        //reachedPassenger.SetActive(false);
        summary.SetActive(false);
        //arrow.SetActive(false);

        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (passengerInTaxi)
        {
            //passenger.transform.SetParent(this.transform);
            Destroy(passenger);
            Debug.Log("Gone");
        }

        if (destinationReached)
        {
            //reachedPassenger.SetActive(true);
            Destroy(destination);
        }

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            summary.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Passenger")
        {
            passengerInTaxi = true;
            Destroy(other.gameObject);
            //arrow.SetActive(true);
        }
        else if (other.gameObject.tag == "Destination")
        {
            destinationReached = true;

            Earnings.instance.EarnMoney();
            Destroy(other.gameObject);
            //arrow.SetActive(true);
        }
    }
}
