using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPassenger : MonoBehaviour
{
    public Transform[] passengerSpawn;
    public Transform[] destinationSpawn;
    public GameObject passenger;
    public GameObject destination;
    private int[][] closePickupPoint;
    private int[][] destinationPoint;
    private int lastDropOff;
    public GameObject pass;

    public static RandomPassenger instance;

    private void Awake()
    {
        instance = this;
        destinationPoint = new int[][]
        {
            /*if random passenger is 0*/ new int[]{3},
            /*if random passenger is 1*/ new int[]{2},
            /*if random passenger is 2*/ new int[]{1},
            /*if random passenger is 3*/ new int[]{0}
        };

        closePickupPoint = new int[][]
        {
            /*if last drop off point is 0*/ new int[]{1, 2},
            /*if last drop off point is 1*/ new int[]{0, 3},
            /*if last drop off point is 2*/ new int[]{0, 3},
            /*if last drop off point is 3*/ new int[]{1, 2}
        };
    }

    // Start is called before the first frame update
    public void Start()
    {
        int randomPassenger = Random.Range(0, passengerSpawn.Length);
        Debug.Log($"spawn {randomPassenger}");
        Instantiate(passenger, passengerSpawn[randomPassenger].position, transform.rotation);
        lastDropOff = destinationPoint[randomPassenger][Random.Range(0, destinationPoint[randomPassenger].Length - 1)];
        Debug.Log($"spawn {lastDropOff}");
        Instantiate(destination, destinationSpawn[lastDropOff].position, transform.rotation);
    }

    public void SpawnPassenger()
    {
        int randomPassenger = closePickupPoint[lastDropOff][Random.Range(0, closePickupPoint[lastDropOff].Length - 1)];
        Debug.Log($"spawn {randomPassenger}");
        lastDropOff = destinationPoint[randomPassenger][Random.Range(0, destinationPoint[randomPassenger].Length - 1)];
        Instantiate(passenger, passengerSpawn[randomPassenger].position, transform.rotation);
        Debug.Log($"spawn {lastDropOff}");
        Instantiate(destination, destinationSpawn[lastDropOff].position, transform.rotation);
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
