using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetLanguage : MonoBehaviour {
	public static int languageIndex;
	public TMP_Dropdown dropDown;
	public TMP_Text playButtonText;
	public TMP_Text instructionsButtonText;
	public TMP_Text creditsButtonText;

	void Awake() {
		dropDown.value = GetPreference("Language");
	}

	void Update() {
		languageIndex = dropDown.value;
		SetPreference("Language");

		switch (dropDown.value) {
			case 0: // English
				playButtonText.text = "PLAY";
				instructionsButtonText.text = "INSTRUCTIONS";
				creditsButtonText.text = "CREDITS";
				break;
			case 1: // Bahasa
				playButtonText.text = "BERMAIN";
				instructionsButtonText.text = "INSTRUKSI";
				creditsButtonText.text = "KREDIT";
				break;
		}
	}

	public void SetPreference(string value) {
		PlayerPrefs.SetInt("Language", dropDown.value);
	}

	public int GetPreference(string value) {
		return PlayerPrefs.GetInt(value);
	}
}