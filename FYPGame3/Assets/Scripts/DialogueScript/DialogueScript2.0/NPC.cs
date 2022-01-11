using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "NPC Dialogue")]
public class NPC : ScriptableObject {
	public new string name;
	[TextArea(3, 15)]
	public string[] dialogue;
	[TextArea(3, 15)]
	public string[] playerDialogue;
}