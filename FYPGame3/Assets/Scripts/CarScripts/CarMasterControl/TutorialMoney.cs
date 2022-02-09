using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialMoney : MonoBehaviour
{
    public TMP_Text earningText;
    public TMP_Text endOfDayText;
    public GameObject insurance;
    public static bool activateInsurance;

    int earnings;

    public static TutorialMoney instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        earnings = PlayerPrefs.GetInt("earnings", 100);
        earningText = transform.Find("Earning").GetComponent<TMP_Text>();
        endOfDayText = transform.Find("EndDayEarnings").GetComponent<TMP_Text>();
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
        insurance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (insurance == false)
        {
            activateInsurance = false;
        }
        else
        {
            activateInsurance = true;
        }
    }

    public void EarnMoney()
    {
        earnings += 5;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
        PlayerPrefs.SetInt("earnings", earnings);
    }
    public void LoseMoney()
    {
        earnings -= 5;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
        insurance.SetActive(false);
    }
    public void LoseMoreMoney()
    {
        earnings -= 10;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
    }
}
