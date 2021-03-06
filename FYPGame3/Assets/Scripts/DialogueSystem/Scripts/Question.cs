using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct Choice {
    [TextArea(2, 3)]
    public string language1;
    [TextArea(2, 3)]
    public string language2;
    public Conversation conversation;
}

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject {
    [TextArea(2, 3)]
    public string language1;
    [TextArea(2, 3)]
    public string language2;
    public Choice[] choices;
}

//conversation[index].question