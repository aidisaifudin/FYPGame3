using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Earnings : MonoBehaviour
{
    public TMP_Text earningText;
    public TMP_Text endOfDayText;

    int earnings = 0;

    public static Earnings instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        earningText = transform.Find("earningText").GetComponent<TMP_Text>();
        endOfDayText = transform.Find("endOfDayText").GetComponent<TMP_Text>();
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EarnMoney()
    {
        earnings += 5;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
    }
}
