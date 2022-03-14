using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BtnLanguage : MonoBehaviour
{

    public TMP_Text skipTutorialText;
    public TMP_Text buyInsuranceText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (SetLanguage.languageIndex)
        {
            case 0: // Bahasa

                skipTutorialText.text = "Lewati tutorial";
                buyInsuranceText.text = "Beli Asuransi";

                break;
            case 1: // English

                skipTutorialText.text = "Skip Tutorial";
                buyInsuranceText.text = "Buy Insurance";
                break;
        }

    }
}
