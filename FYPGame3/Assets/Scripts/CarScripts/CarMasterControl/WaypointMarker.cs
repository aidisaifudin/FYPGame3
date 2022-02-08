using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaypointMarker : MonoBehaviour
{
    // Indicator icon
    public Image img;
    // The target (location, enemy, etc..)
    public Transform target;
    // UI Text to display the distance
    public TMP_Text meter;
    // To adjust the position of the icon
    public Vector3 offset;
    public GameObject passengerSpawner;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Passenger").transform;
    }

    void Update()
    {
        if (TaxiManager.passengerInTaxi)
        {
            target = GameObject.FindGameObjectWithTag("Destination").transform;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Passenger").transform;
        }

        //Debug.Log(RandomPassenger.pass);

        // Giving limits to the icon so it sticks on the screen
        // Below calculations witht the assumption that the icon anchor point is in the middle
        // Minimum X position: half of the icon width
        float minX = img.GetPixelAdjustedRect().width / 2;
        // Maximum X position: screen width - half of the icon width
        float maxX = Screen.width - minX;

        // Minimum Y position: half of the height
        float minY = (Screen.height * 1 / 4) - img.GetPixelAdjustedRect().height / 2;
        // Maximum Y position: screen height - half of the icon height
        float maxY = (Screen.height * 3 / 4) - minY;
        //float minY = Screen.height / 2;
        //float maxY = Screen.height / 2;

        // Temporary variable to store the converted position from 3D world point to 2D screen point
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

        // Check if the target is behind us, to only show the icon once the target is in front
        if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            // Check if the target is on the left side of the screen
            if (pos.x < Screen.width / 2)
            {
                // Place it on the right since it is behind the player (opposite side)
                pos.x = maxX;
            }
            else
            {
                // Place it on the left side
                pos.x = minX;
            }
        }

        // Limit the X and Y positions
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Update the marker's position
        img.transform.position = pos;
        // Change the meter text to the distance with the meter unit 'm'
        meter.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
    }
    //public Image marker;
    //public Transform destination;
    //public Transform passenger;
    //public Transform dest;
    //public Vector3 offset;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    passenger = transform.Find("FChar2_A").GetComponent<Transform>();
    //    dest = transform.Find("Destination").GetComponent<Transform>();
    //    this.transform.SetParent(passenger);
    //}

    //// Update is called once per frame
    //private void Update()
    //{
    //    if (TaxiManager.passengerInTaxi)
    //    {
    //        this.transform.SetParent(null);
    //        this.transform.SetParent(dest);
    //    }

    //    if (TaxiManager.findingPassenger)
    //    {
    //        this.transform.SetParent(null);
    //        this.transform.SetParent(passenger);
    //    }

    //    float minX = marker.GetPixelAdjustedRect().width / 2;
    //    float maxX = Screen.width - minX;

    //    float minY = marker.GetPixelAdjustedRect().height / 2;
    //    float maxY = Screen.height - minY;

    //    Vector2 pos = Camera.main.WorldToScreenPoint(destination.position);

    //    if (Vector3.Dot((destination.position - transform.position), transform.forward) < 0)
    //    {
    //        if (pos.x < Screen.width / 2)
    //        {
    //            pos.x = maxX;
    //        }
    //        else
    //        {
    //            pos.x = minX;
    //        }
    //    }

    //    pos.x = Mathf.Clamp(pos.x, minX, maxX);
    //    pos.y = Mathf.Clamp(pos.y, minY, maxY);

    //    marker.transform.position = dest.transform.position;
    //}
}
