using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionController : MonoBehaviour {
	public Question question;
    public TMP_Text title;
    public TMP_Text questionText;
	public Button choiceTemplateButton;

	private List<ChoiceController> choiceControllers = new List<ChoiceController>();

	public void Change(Question _question) {
		RemoveChoices();
		question = _question;
		gameObject.SetActive(true);
		Initialize();
	}

	public void Hide(Conversation conversation) {
		RemoveChoices();
		gameObject.SetActive(false);
	}

	private void RemoveChoices() {
		foreach(ChoiceController c in choiceControllers)
			Destroy(c.gameObject);

		choiceControllers.Clear();
	}

	private void Initialize() {
        switch (SetLanguage.languageIndex)
        {
            case 0:
                title.text = "Pertanyaan";
                questionText.text = question.language1;
                break;
            case 1:
                title.text = "Question";
                questionText.text = question.language2;
                break;
        }

        for (int index = 0; index < question.choices.Length; index++) {
			ChoiceController c = ChoiceController.AddChoiceButton(choiceTemplateButton, question.choices[index], index);
			choiceControllers.Add(c);
		}

		choiceTemplateButton.gameObject.SetActive(false);
	}
}