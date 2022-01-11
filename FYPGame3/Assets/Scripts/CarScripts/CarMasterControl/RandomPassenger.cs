using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPassenger : MonoBehaviour
{
    public Vector3[] passengerSpawn;
    public Vector3[] destinationSpawn;
    public GameObject passenger;
    public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        int randomPassenger = Random.Range(0, passengerSpawn.Length);
        int randomDestination = Random.Range(0, destinationSpawn.Length);

        Instantiate(passenger, passengerSpawn[randomPassenger], transform.rotation);
        Instantiate(destination, destinationSpawn[randomDestination], transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (TaxiManager.destinationReached)
        {
            int randomPassenger = Random.Range(0, passengerSpawn.Length);
            int randomDestination = Random.Range(0, destinationSpawn.Length);

            Instantiate(passenger, passengerSpawn[randomPassenger], transform.rotation);
            Instantiate(destination, destinationSpawn[randomDestination], transform.rotation);
            TaxiManager.destinationReached = false;
        }
    }
}
