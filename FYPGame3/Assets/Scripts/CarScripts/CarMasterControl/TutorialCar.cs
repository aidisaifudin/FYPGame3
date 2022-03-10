using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialCar : MonoBehaviour
{
    public GameObject passenger;
    public GameObject destination;
    public GameObject summary;
    public bool destinationReached;
    public GameObject tryAgainBtn;
    public TMP_Text earningText;
    public TMP_Text endOfDayText;
    public TMP_Text lossesText;
    public TMP_Text earnedText;
    public TMP_Text goodJob;
    public TMP_Text driveBetter;
    public GameObject insurance;
    public GameObject insuranceTab;
    public GameObject insuranceButton;
    public bool insuranceActivated;

    public GameObject scorePrefab;
    public GameObject scorePrefab1;

    public GameObject closeBtn;

    public int earnedTutorial = 0;
    public int lossesTutorial = 0;
    public int earningsTutorial = 100;

    // Start is called before the first frame update
    void Start()
    {
        passenger = GameObject.FindGameObjectWithTag("Passenger");
        destination = GameObject.FindGameObjectWithTag("Destination");
        summary.SetActive(false);
        earnedText = transform.Find("EndDayEarnings").GetComponent<TMP_Text>();

        lossesText = transform.Find("Losses").GetComponent<TMP_Text>();

        earningText = transform.Find("Earning").GetComponent<TMP_Text>();

        endOfDayText = transform.Find("Total Earnings").GetComponent<TMP_Text>();

        goodJob = transform.Find("Good Job!").GetComponent<TMP_Text>();
        goodJob.gameObject.SetActive(false);

        driveBetter = transform.Find("Drive Better").GetComponent<TMP_Text>();
        driveBetter.gameObject.SetActive(false);

        destinationReached = false;

        insurance.SetActive(false);
        insuranceActivated = false;
    }

    // Update is called once per frame
    void Update()
    {

        earnedText.text = " Earnings For Today: " + earnedTutorial.ToString();
        lossesText.text = "Losses For Today: " + lossesTutorial.ToString();
        earningText.text = " : " + earningsTutorial.ToString();
        endOfDayText.text = "Total Amount: " + earningsTutorial.ToString();

        if (destinationReached)
        {
            earnedTutorial += 50;
            earningsTutorial += 50;
            destinationReached = false;
            summary.SetActive(true);
            Time.timeScale = 0;
            tryAgainBtn.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (earningsTutorial <= 0)
        {
            earningsTutorial = 0;
            Time.timeScale = 0;
            summary.SetActive(true);
            closeBtn.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Passenger")
        {
            //passengerInTaxi = true;
            Destroy(other.gameObject);
            //arrow.SetActive(true);
        }

        else if (other.gameObject.tag == "Destination")
        {
            destinationReached = true;

            //Earnings.instance.EarnMoney();
            Destroy(other.gameObject);
            //RandomPassenger.instance.SpawnPassenger();
            //arrow.SetActive(true);
        }

        else if (other.gameObject.layer == 9)
        {
            if (insuranceActivated == true)
            {
                Debug.Log("It hit");
                //Earnings.instance.LoseMoney();
                lossesTutorial += 5;
                earningsTutorial -= 5;
                GameObject scoreText1 = Instantiate(scorePrefab1, transform.position, transform.rotation) as GameObject;
                scoreText1.transform.Rotate(0f, 180f, 0f);
                Destroy(scoreText1, 1);
                scoreText1.GetComponent<TextMesh>().text = "-5";

            }
            else if (insuranceActivated == false)
            {
                Debug.Log("It hit");
                //Earnings.instance.LoseMoreMoney();
                lossesTutorial += 5;
                earningsTutorial -= 5;
                GameObject scoreText = Instantiate(scorePrefab, transform.position, transform.rotation) as GameObject;
                scoreText.transform.Rotate(0f, 180f, 0f);
                Destroy(scoreText, 1);
                scoreText.GetComponent<TextMesh>().text = "-10";
            }
        }
    }

    public void CloseSummary()
    {
        destinationReached = false;
        summary.SetActive(false);
        Debug.Log("Close Summary");
        Time.timeScale = 1;
        
    }

    public void RestartLevel()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Tutorial");
    }

    public void OpenInsurance()
    {
        insuranceTab.SetActive(true);
        Time.timeScale = 0;
    }

    public void InsuranceChoose()
    {
        insurance.SetActive(true);
        insuranceTab.SetActive(false);
        earningsTutorial -= 50;
        insuranceButton.SetActive(false);
        insuranceActivated = true;
        Time.timeScale = 1;
    }

    public void InsuranceNoChoose()
    {
        insurance.SetActive(false);
        insuranceTab.SetActive(false);
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
