using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line {
	public Character character;
	public int spriteIndex;

    [TextArea(2, 3)]
    public string language1;
    [TextArea(2, 3)]
    public string language2;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject {
	public Character speakerLeft;
	public Character speakerRight;
	public Line[] lines;
	public Question question;
	public Conversation nextConversatíon;
}