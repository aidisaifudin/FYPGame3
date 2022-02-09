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

    public static string timer;

    // Start is called before the first frame update
    void Start()
    {
        timeText = transform.Find("timeText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY; //day increase when real seconds per in game day ends

        float dayNormalized = day % 3f; //start day at 8am, end day at 24:00 resetting to 00:00

        float hoursPerDay = 8f;
        float minutesPerHour = 60f;

        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeText.text = hoursString + ":" + minutesString;
        timer = timeText.text;
        SaveTime();
    }

    private void SaveTime()
    {
        PlayerPrefs.SetString("time", timer);
        Debug.Log(timer);
    }
}
