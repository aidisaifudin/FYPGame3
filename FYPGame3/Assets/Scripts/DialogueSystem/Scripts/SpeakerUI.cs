using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUI : MonoBehaviour {
	public Image portrait;
	public TMP_Text dialog;
	public TMP_Text fullName;
	public static bool isTyping;
	public float typeSpeed;
	//bool oneTime = false;
	//public bool isActive;

	private Character speaker;
	public Character Speaker {
		get { return speaker; }
		set {
			speaker = value;
			portrait.sprite = speaker.avatar;
			fullName.text = speaker.fullName;
		}
	}

	void Awake() {
		isTyping = false;
	}

	public string Dialog {
		set { dialog.text = value; }
	}

	public bool HasSpeaker() {
		return speaker != null;
	}

	public bool SpeakerIs(Character character) {
		return speaker == character;
	}

	//public void Show() {
	//	gameObject.SetActive(true);
	//}

	//public void Hide() {
	//	gameObject.SetActive(false);
	//}

	public void Show(string typingText) {
		gameObject.SetActive(true);
		dialog.text = "";
		isTyping = true;
		StopAllCoroutines();
		StartCoroutine(TypeEffect(typingText));
		//isActive = true;
	}

	public void Hide() {
		gameObject.SetActive(false);
		StopAllCoroutines();
		dialog.text = "";
		//oneTime = false;
		//isActive = false;
	}

	//public void SetText() {
	//	StopAllCoroutines();
	//	StartCoroutine();
	//	//TypeEffect(dialog.text)
	//}

	public IEnumerator TypeEffect(string text) {
		foreach(char letter in text.ToCharArray()) {
			//text += letter;
			dialog.text += letter;
			yield return new WaitForSecondsRealtime(typeSpeed);
		}

		isTyping = false;
	}
}