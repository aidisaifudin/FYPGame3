using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarBang : MonoBehaviour

{
    private Animator anim;
    public GameObject scorePrefab;
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

                    Earnings.instance.LoseMoney();
                    // GameObject scoreText1 = Instantiate(scorePrefab1, transform.position, transform.rotation) as GameObject;
                    // scoreText1.transform.Rotate(0f, 180f, 0f);
                    // Destroy(scoreText1, 5);
                    // scoreText1.GetComponent<TextMesh>().text = "-5";

                }
                else if (Earnings.activateInsurance == false)
                {
                    Debug.Log("It hit");
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
        invincible = true;
        yield return new WaitForSeconds(10.0f);
        GetComponent<Animator>().SetBool("Minus", false);
        invincible = false;
        Debug.Log("coroutineA running again");
    }
}
