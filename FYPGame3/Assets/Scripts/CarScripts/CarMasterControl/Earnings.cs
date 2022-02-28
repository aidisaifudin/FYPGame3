using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Earnings : MonoBehaviour
{
    public TMP_Text earningText;
    public TMP_Text endOfDayText;
    public TMP_Text lossesText;
    public TMP_Text earnedText;
    public TMP_Text goodJob;
    public TMP_Text driveBetter;
    public GameObject insurance;
    public static bool activateInsurance;

    public static int earnings = 100;
    public static int endDayMoney = 100;
    public static int earned = 0;
    public static Earnings instance;
    public static int losses = 0;

    public GameObject insuranceTab;
    public GameObject insuranceButton;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        earnings = 100;
        earned = PlayerPrefs.GetInt("earned", 0);
        earnedText = transform.Find("EndDayEarnings").GetComponent<TMP_Text>();
        earnedText.text = " Earnings For Today: " + PlayerPrefs.GetInt("earned", 0).ToString();

        losses = PlayerPrefs.GetInt("losses", 0);
        lossesText = transform.Find("Losses").GetComponent<TMP_Text>();
        lossesText.text = " Losses For Today: " + PlayerPrefs.GetInt("losses", 0).ToString();

        earnings = PlayerPrefs.GetInt("earnings", earnings);
        earningText = transform.Find("Earning").GetComponent<TMP_Text>();
        earningText.text = " : " + PlayerPrefs.GetInt("earnings", 100).ToString();

        endOfDayText = transform.Find("Total Earnings").GetComponent<TMP_Text>();
        endOfDayText.text = " Total Amount: " + PlayerPrefs.GetInt("endDayMoney", 100).ToString();

        goodJob = transform.Find("Good Job!").GetComponent<TMP_Text>();
        goodJob.gameObject.SetActive(false);

        driveBetter = transform.Find("Drive Better").GetComponent<TMP_Text>();
        driveBetter.gameObject.SetActive(false);

        insurance.SetActive(false);
        activateInsurance = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(earnings);
        
        //{
        //if (insurance == false)
        //    activateInsurance = false;
        //}
        //else if (insurance == true)
        //{
        //    activateInsurance = true;
        //}

        
        
    }

    public void EarnMoney()
    {
        earnings += 50;
        earned += 50;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Total Amount: " + earnings.ToString();
        lossesText.text = "Losses For Today: " + losses.ToString();
        earnedText.text = "Earnings For Today: " + earned.ToString();
        PlayerPrefs.SetInt("earnings", earnings);
        PlayerPrefs.SetInt("endDayMoney", earnings);
        PlayerPrefs.SetInt("earned", earned);
        PlayerPrefs.SetInt("losses", losses);
    }

    public void LoseMoney()
    {
        Debug.Log("Lose money");
        earnings -= 5;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Total Amount: " + earnings.ToString();
        lossesText.text = "Losses For Today: " + losses.ToString();
        earnedText.text = "Earning For Today: " + earned.ToString();
        losses += 5;
        PlayerPrefs.SetInt("earnings", earnings);
        PlayerPrefs.SetInt("endDayMoney", earnings);
        PlayerPrefs.SetInt("earned", earned);
        PlayerPrefs.SetInt("losses", losses);
    }

    public void LoseMoreMoney()
    {
        Debug.Log("Lose more money");
        earnings -= 10;
        losses -= 10;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Total Amount: " + earnings.ToString();
        lossesText.text = "Losses For Today: " + losses.ToString();
        earnedText.text = "Earning For Today: " + earned.ToString();
        PlayerPrefs.SetInt("earnings", earnings);
        PlayerPrefs.SetInt("endDayMoney", earnings);
        PlayerPrefs.SetInt("earned", earned);
        PlayerPrefs.SetInt("losses", losses);
    }

    public void OpenInsurance()
    {
        insuranceTab.SetActive(true);
    }
    public void InsuranceChoose()
    {
        insurance.SetActive(true);
        insuranceTab.SetActive(false);
        earnings -= 50;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
        PlayerPrefs.SetInt("earnings", earnings);
        PlayerPrefs.SetInt("endDayMoney", earnings);
        insuranceButton.SetActive(false);
        activateInsurance = true;
    }

    public void InsuranceNoChoose()
    {
        insurance.SetActive(false);
        insuranceTab.SetActive(false);
    }

    public void GoodJob()
    {
        goodJob.gameObject.SetActive(true);
    }

    public void DriveBetter()
    {
        driveBetter.gameObject.SetActive(true);
    }
}
