using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {
	public GameObject tab;
	bool status;

	void Update() {
		if(Input.GetKeyDown(KeyCode.Tab)) {
			status = !status;
			tab.SetActive(status);
		}
	}
}