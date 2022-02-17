using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {
	public float fadeTime;
	public float startTime;

	void Start() {
		startTime = Time.time;
	}

	void Update() {
		// Make text move upwards
		transform.Translate(0, Time.deltaTime * 1.0f, 0);
		
		// Compute and set alpha value
		float newAlpha = 1.0f - (Time.time - startTime) / fadeTime;
		GetComponent<TextMesh>().color = new Color(1, 1, 1, newAlpha);
		
		// If alpha decreased to zero, destroy this game object
		if(newAlpha <= 0) {
			Destroy(gameObject);
		}
	}
}