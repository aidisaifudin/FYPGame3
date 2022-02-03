using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPassenger : MonoBehaviour
{
    public Transform[] passengerSpawn;
    public Transform[] destinationSpawn;
    public GameObject passenger;
    public GameObject destination;
    public int[][] closePickupPoint;
    public int[][] destinationPoint;
    private int lastDropOff;

    public static RandomPassenger instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    public void Start()
    {
        
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        destination = GameObject.FindGameObjectWithTag("Destination");
        int randomPassenger = Random.Range(0, passengerSpawn.Length);
        //int pickedPassenger = closePickupPoint[randomPassenger][4];

        Instantiate(passenger, passengerSpawn[randomPassenger].position, transform.rotation);
        Debug.Log("spawn");
        //lastDropOff = destinationPoint[randomPassenger][Random.Range(0, destinationPoint[randomPassenger].Length - 1)];


        //Instantiate(destination, destinationSpawn[lastDropOff].position, transform.rotation);
    }

    public void SpawnPassenger()
    {
        {
            int randomPassenger = closePickupPoint[lastDropOff][Random.Range(0, closePickupPoint[lastDropOff].Length - 1)];
            lastDropOff = destinationPoint[randomPassenger][Random.Range(0, destinationPoint[randomPassenger].Length - 1)];
            Instantiate(passenger, passengerSpawn[randomPassenger].position, transform.rotation);
            Instantiate(destination, destinationSpawn[lastDropOff].position, transform.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //if (TaxiManager.destinationReached)
        //{
        //    //nextPassenger = Mathf.Abs(int.Parse(destinationSpawn[0].ToString()) - 1);
        //    int randomPassenger = Random.Range(0, passengerSpawn.Length);
        //    int randomDestination = Random.Range(0, destinationSpawn.Length);

        //    Instantiate(passenger, passengerSpawn[randomPassenger].position, transform.rotation);
        //    Instantiate(destination, destinationSpawn[randomDestination].position, transform.rotation);
        //    TaxiManager.destinationReached = false;
        //}
    }

    //Vector3[] ChooseRandomDestination(int numRequired)
    //{
    //    Vector3[] result = new Vector3[numRequired];
    //    int numToChoose = numRequired;

    //    for (int numLeft = destinationSpawn.Length; numLeft > 0; numLeft--)
    //    {
    //        float probability = (numToChoose + 0.0f) / (numLeft + 0.0f); // Adding 0.0 is simply to cast the integers to float for division operation

    //        if (Random.value <= probability)
    //        {
    //            numToChoose--;
    //            result[numToChoose] = destinationSpawn[numLeft - 1];

    //            if (numToChoose == 0)
    //                break;
    //        }
    //    }
    //    return destinationSpawn;
    //}
}
