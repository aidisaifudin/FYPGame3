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

    public GameObject insuranceTabEnglish;
    public GameObject insuranceTabBahasa;

    public GameObject insuranceButton;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        earnings = 100;
        earned = 0;
        losses = 0;
        earned = PlayerPrefs.GetInt("earned", earned);
        earnedText = transform.Find("EndDayEarnings").GetComponent<TMP_Text>();
        earnedText.text = " Earnings For Today: " + PlayerPrefs.GetInt("earned", 0).ToString();

        losses = PlayerPrefs.GetInt("losses", losses);
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
        //insuranceTab.SetActive(true);
        switch (SetLanguage.languageIndex)
        {
            case 0: // Bahasa

                insuranceTabBahasa.SetActive(true);

                break;
            case 1: // English

                insuranceTabEnglish.SetActive(true);
                break;
        }
        Time.timeScale = 0;
    }
    public void InsuranceChoose()
    {
        insurance.SetActive(true);
        insuranceTabBahasa.SetActive(false);
        insuranceTabEnglish.SetActive(false);
        //insuranceTab.SetActive(false);
        earnings -= 50;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Total Amount: " + earnings.ToString();
        PlayerPrefs.SetInt("earnings", earnings);
        PlayerPrefs.SetInt("endDayMoney", earnings);
        insuranceButton.SetActive(false);
        activateInsurance = true;
        Time.timeScale = 1;
    }

    public void InsuranceNoChoose()
    {
        insurance.SetActive(false);
        insuranceTabBahasa.SetActive(false);
        insuranceTabEnglish.SetActive(false);
        //insuranceTab.SetActive(false);
        Time.timeScale = 1;
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
