using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointMarker : MonoBehaviour
{
    public Image marker;
    public Transform destination;
    public GameObject passenger;
    public GameObject dest;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        dest = GameObject.FindGameObjectWithTag("Destination");
        //this.SetParent(passenger);
    }

    // Update is called once per frame
    private void Update()
    {
        //if (TaxiManager.passengerInTaxi)
        //{
        //    this.SetParent(null);
        //    this.SetParent(dest);
        //}

        //if (TaxiManager.findingPassenger)
        //{
        //    this.SetParent(null);
        //    this.SetParent(passenger);
        //}

        float minX = marker.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = marker.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        Vector2 pos = Camera.main.WorldToScreenPoint(destination.position);

        if (Vector3.Dot((destination.position - transform.position), transform.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        marker.transform.position = dest.transform.position;
    }
}
