using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMessage : MonoBehaviour {
	public GameObject message;

	public void ShowMessage() {
		message.SetActive(true);
	}
}