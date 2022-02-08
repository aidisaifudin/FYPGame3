using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour {
	public Conversation[] conversation;
	public GameObject message;

	public GameObject speakerLeft;
	public GameObject speakerRight;

	private SpeakerUI speakerUILeft;
	private SpeakerUI speakerUIRight;

	private int activeLineIndex;
	private bool conversationStarted;
	private QuestionController questionController;

	[SerializeField]
	private GameObject questionPanel;

	public void ChangeConversation(Conversation nextConversation) {
		conversationStarted = false;
		conversation[ActivateTrigger.index] = nextConversation;
		AdvanceLine();
	}

	void Start() {
		activeLineIndex = 0;

		speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
		speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

		questionController = questionPanel.GetComponent<QuestionController>();
	}

	void Update() {
		if(ActivateTrigger.index >= 0)
			message.SetActive(true);

		if(Input.GetKeyDown(KeyCode.Return)) // For keyboard input
			if(ActivateTrigger.index >= 0 && SpeakerUI.isTyping == false) {
				AdvanceLine();
			}

		if(Input.GetKeyDown(KeyCode.X))
			EndConversation();
	}

	// For mobile input
	public void NextDialog() {
		if(ActivateTrigger.index >= 0 && SpeakerUI.isTyping == false)
			AdvanceLine();
	}

	void EndConversation() {
		conversationStarted = false;
		activeLineIndex = 0;
		speakerUILeft.Hide();
		speakerUIRight.Hide();
		ActivateTrigger.index = -1;
		message.SetActive(false);
		Time.timeScale = 1;
	}

	void Initialize() {
		conversationStarted = true;
		activeLineIndex = 0;
		speakerUILeft.Speaker = conversation[ActivateTrigger.index].speakerLeft;
		speakerUIRight.Speaker = conversation[ActivateTrigger.index].speakerRight;
	}

	void AdvanceLine() {
		if(conversation == null)
			return;

		if(!conversationStarted)
			Initialize();

		if(activeLineIndex < conversation[ActivateTrigger.index].lines.Length) {
			DisplayLine();
		} else {
			AdvanceConversation();
		}
	}

	void DisplayLine() {
		Line line = conversation[ActivateTrigger.index].lines[activeLineIndex];
		Character character = line.character;

		if(speakerUILeft.SpeakerIs(character)) {
			SetDialog(speakerUILeft, speakerUIRight, line.text);
		} else {
			SetDialog(speakerUIRight, speakerUILeft, line.text);
		}

		activeLineIndex += 1;
	}

	void AdvanceConversation() {
		if(conversation[ActivateTrigger.index].question != null)
			questionController.Change(conversation[ActivateTrigger.index].question);
		else if(conversation[ActivateTrigger.index].nextConversatíon != null)
			ChangeConversation(conversation[ActivateTrigger.index].nextConversatíon);
		else
			EndConversation();
	}

	void SetDialog(SpeakerUI activeSpeakerUI, SpeakerUI inactiveSpeakerUI, string text) {
		activeSpeakerUI.Show(text);
		inactiveSpeakerUI.Hide();
	}
}