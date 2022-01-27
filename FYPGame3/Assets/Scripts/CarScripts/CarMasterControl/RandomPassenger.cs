using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPassenger : MonoBehaviour
{
    public Transform[] passengerSpawn;
    public Transform[] destinationSpawn;
    public GameObject passenger;
    public GameObject destination;
    int[] closePickupPoint;
    int[] destinationPoint;

    // Start is called before the first frame update
    void Start()
    {
        int randomPassenger = Random.Range(0, pickedPassenger.Length - 1);
        int pickedPassenger = closePickupPoint[randomPassenger];



        int randomDestination = Random.Range(0, destinationSpawn.Length);

        Instantiate(passenger, passengerSpawn[randomPassenger].position, transform.rotation);
        Instantiate(destination, destinationSpawn[randomDestination].position, transform.rotation);
    }

    void SpawnPassenger()
    {
        switch (closePickupPoint)
        {
            case destinationPoint[0]:
            case destinationPoint[3]:
                int randomPassenger = Random.Range(0, pickedPassenger.Length - 1);
                int pickedPassenger = closePickupPoint[randomPassenger];
            case destinationPoint[1]:
            case destinationPoint[2]:
                int randomPassenger = Random.Range(0, pickedPassenger.Length - 1);
                int pickedPassenger = closePickupPoint[randomPassenger];
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (TaxiManager.destinationReached)
        {
            //nextPassenger = Mathf.Abs(int.Parse(destinationSpawn[0].ToString()) - 1);
            int randomPassenger = Random.Range(0, passengerSpawn.Length);
            int randomDestination = Random.Range(0, destinationSpawn.Length);

            Instantiate(passenger, passengerSpawn[randomPassenger].position, transform.rotation);
            Instantiate(destination, destinationSpawn[randomDestination].position, transform.rotation);
            TaxiManager.destinationReached = false;
        }
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
