using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarBang : MonoBehaviour

{
    private Animator anim;
    public GameObject scorePrefab;
    public GameObject minus5;
    private bool invincible = false;
    // public GameObject scorePrefab1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            if (!invincible)
            {
                if (Earnings.activateInsurance == true)
                {

                    Debug.Log("It hit minus5");
                    minus5.SetActive(true);
                    GetComponent<Animator>().SetBool("Minus5", true);
                    invincible = true;

                    StartCoroutine(Minus5());
                    Earnings.instance.LoseMoney();


                }
                else if (Earnings.activateInsurance == false)
                {
                   
                    scorePrefab.SetActive(true);
                    GetComponent<Animator>().SetBool("Minus", true);
                    invincible = true;
                    
                    StartCoroutine(Minus10());
                    Earnings.instance.LoseMoreMoney();

                }
            }
        }
    }
    IEnumerator Minus10()
    {
        // wait for 1 second
        Debug.Log("coroutineA created");
        Handheld.Vibrate();
        invincible = true;
        yield return new WaitForSeconds(10.0f);
        
        GetComponent<Animator>().SetBool("Minus", false);
        invincible = false;
        Debug.Log("coroutineA running again");
    }
    IEnumerator Minus5()
    {
        // wait for 1 second
        Debug.Log("coroutineA created");
        Handheld.Vibrate();
        invincible = true;
        yield return new WaitForSeconds(10.0f);
        GetComponent<Animator>().SetBool("Minus5", false);
        invincible = false;
        Debug.Log("coroutineA running again");
    }
    public void Minus5Tutorial()
    {
        Debug.Log("It hit minus5");
        Handheld.Vibrate();
        minus5.SetActive(true);
        GetComponent<Animator>().SetBool("Minus5", true);
        invincible = true;

        // StartCoroutine(Minus5());
        Earnings.instance.LoseMoney();
    }
}
