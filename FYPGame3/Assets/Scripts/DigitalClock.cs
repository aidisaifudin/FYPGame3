using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DigitalClock : MonoBehaviour
{

    public float day;
    public const float REAL_SECONDS_PER_INGAME_DAY = 300f;

    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = transform.Find("timeText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY; //day increase when real seconds per in game day ends

        float dayNormalized = day % 1f; //make day variable to 0-1

        float hoursPerDay = 24f;
        float minutesPerHour = 60f;

        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeText.text = hoursString + ":" + minutesString;
    }
}
