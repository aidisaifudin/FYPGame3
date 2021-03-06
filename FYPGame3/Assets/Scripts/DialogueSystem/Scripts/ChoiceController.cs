using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class ConversationChangeEvent : UnityEvent<Conversation> {}

public class ChoiceController : MonoBehaviour {
	public Choice choice;
	public ConversationChangeEvent conversationChangeEvent;

	public static ChoiceController AddChoiceButton(Button choiceButtonTemplate, Choice choice, int index) {
		int buttonSpacing = -80;
		Button button = Instantiate(choiceButtonTemplate);

		button.transform.SetParent(choiceButtonTemplate.transform.parent);
		button.transform.localScale = Vector3.one;
		button.transform.localPosition = new Vector3(0, (index * buttonSpacing) - 40f, 0);
		button.name = "Choice " + (index + 1);
		button.gameObject.SetActive(true);

		ChoiceController choiceController = button.GetComponent<ChoiceController>();
		choiceController.choice = choice;

		return choiceController;
	}

	private void Start() {
		if(conversationChangeEvent == null)
			conversationChangeEvent = new ConversationChangeEvent();

        switch (SetLanguage.languageIndex)
        {
            case 0:
                GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = choice.language1;
                break;
            case 1:
                GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = choice.language2;
                break;
        }

        GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
	}

	public void MakeChoice() {
		conversationChangeEvent.Invoke(choice.conversation);
	}
}