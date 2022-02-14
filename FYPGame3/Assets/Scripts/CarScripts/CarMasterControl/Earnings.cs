using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Earnings : MonoBehaviour
{
    public TMP_Text earningText;
    public TMP_Text endOfDayText;
    public GameObject insurance;
    public static bool activateInsurance;

    public static int earnings = 5;
    public static int endDayMoney = 100;
    public static Earnings instance;

    public GameObject insuranceTab;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        earnings = 100;
        earnings = PlayerPrefs.GetInt("earnings", earnings);
        earningText = transform.Find("Earning").GetComponent<TMP_Text>();
        earningText.text = " : " + PlayerPrefs.GetInt("earnings", 5).ToString();
        endOfDayText = transform.Find("EndDayEarnings").GetComponent<TMP_Text>();
        endOfDayText.text = " Earnings for today: " + PlayerPrefs.GetInt("endDayMoney", 100).ToString();
        insurance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(earnings);
        
        if (insurance == false)
        {
            activateInsurance = false;
        }
        else if (insurance == true)
        {
            activateInsurance = true;
        }

        
        
    }

    public void EarnMoney()
    {
        earnings += 50;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
        PlayerPrefs.SetInt("earnings", earnings);
        PlayerPrefs.SetInt("endDayMoney", earnings);
    }
    public void LoseMoney()
    {
        Debug.Log("Lose money");
        earnings -= 5;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
        insurance.SetActive(false);
        PlayerPrefs.SetInt("earnings", earnings);
        PlayerPrefs.SetInt("endDayMoney", earnings);
    }
    public void LoseMoreMoney()
    {
        Debug.Log("Lose more money");
        earnings -= 10;
        earningText.text = " : " + earnings.ToString();
        endOfDayText.text = " Earnings for today: " + earnings.ToString();
        PlayerPrefs.SetInt("earnings", earnings);
        PlayerPrefs.SetInt("endDayMoney", earnings);
    }

    public void OpenInsurance()
    {
        insuranceTab.SetActive(true);
    }
    public void InsuranceChoose()
    {
        insurance.SetActive(true);
        insuranceTab.SetActive(false);
    }

    public void InsuranceNoChoose()
    {
        insurance.SetActive(false);
        insuranceTab.SetActive(false);
    }
}
