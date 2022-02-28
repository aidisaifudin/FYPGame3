using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ConversationControllerScenario : MonoBehaviour {
	public Conversation conversation;
	public GameObject notification;
    public TMP_Text message1;
    public TMP_Text message2;

    public GameObject speakerLeft;
	public GameObject speakerRight;

	private SpeakerUI speakerUILeft;
	private SpeakerUI speakerUIRight;

	private int activeLineIndex;
	private bool conversationStarted = false;
	private QuestionController quesController;

	[SerializeField]
	private GameObject questionPanel;

	public void ChangeConversation(Conversation nextConversation) {
		conversationStarted = false;
		conversation = nextConversation;
		AdvanceLine();
	}

	private void Start() {
        switch (SetLanguage.languageIndex)
        {
            case 0: // English
                message1.text = "INCOMING MESSAGE\n\nTOUCH HERE TO CONTINUE...";
                message2.text = "TAP ON DIALOG BOX TO SCROLL";
                break;
            case 1: // Bahasa
                message1.text = "PESAN YANG MASUK\n\nSENTUH DI SINI UNTUK LANJUTKAN...";
                message2.text = "TAP PADA KOTAK DIALOG UNTUK GULIR";
                break;
        }

        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
		speakerUIRight = speakerRight.GetComponent<SpeakerUI>();
		quesController = questionPanel.GetComponent<QuestionController>();
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Return) && SpeakerUI.isTyping == false)
			AdvanceLine();

		if(Input.GetKeyDown(KeyCode.X))
			EndConversation();
	}

	// For mobile input
	public void NextDialog() {
		if(SpeakerUI.isTyping == false)
			AdvanceLine();
	}

	private void EndConversation() {
		conversation = null;
		conversationStarted = false;
		speakerUILeft.Hide();
		speakerUIRight.Hide();
        notification.SetActive(false);
	}

	private void Initialize() {
		conversationStarted = true;
		activeLineIndex = 0;
		speakerUILeft.Speaker = conversation.speakerLeft;
		speakerUIRight.Speaker = conversation.speakerRight;
	}

	private void AdvanceLine() {
		if(conversation == null)
			return;
		if(!conversationStarted)
			Initialize();

		if(activeLineIndex < conversation.lines.Length)
			DisplayLine();
		else
			AdvanceConversation();
	}

	void DisplayLine() {
		Line line = conversation.lines[activeLineIndex];
		Character character = line.character;

		if(speakerUILeft.SpeakerIs(character)) {
            switch (SetLanguage.languageIndex)
            {
                case 0:
                    SetDialog(speakerUILeft, speakerUIRight, line.language1);
                    break;
                case 1:
                    SetDialog(speakerUILeft, speakerUIRight, line.language2);
                    break;
            }
        } else {
            switch (SetLanguage.languageIndex)
            {
                case 0:
                    SetDialog(speakerUIRight, speakerUILeft, line.language1);
                    break;
                case 1:
                    SetDialog(speakerUIRight, speakerUILeft, line.language2);
                    break;
            }
        }

		activeLineIndex += 1;
	}

	void AdvanceConversation() {
		//可以改善的地方：三个不同的类型在一个methods下
		//should be three different objects with a standard interface
		if(conversation.question != null)
			quesController.Change(conversation.question);
		else if(conversation.nextConversatíon != null)
			ChangeConversation(conversation.nextConversatíon);
		else
			EndConversation();
	}

	void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text) {
		activeSpeakerUI.Show(text);
		inactiveSpeakerUI.Hide();
	}
}