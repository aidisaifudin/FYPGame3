using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour {
	public static int index;

	void Start() {
		index = -1;
	}

	void OnTriggerExit(Collider other) {
        
		//Time.timeScale = 0;
        
		switch(other.tag) {
			case "Passenger1":
				index = 0;
				Destroy(other.gameObject);
                Time.timeScale = 0;
                break;
			case "Passenger2":
				index = 1;
				Destroy(other.gameObject);
                Time.timeScale = 0;
                break;
            case "Passenger3":
                index = 2;
                Destroy(other.gameObject);
                Time.timeScale = 0;
                break;
            case "Passenger4":
                index = 3;
                Destroy(other.gameObject);
                Time.timeScale = 0;
                break;
            case "Passenger5":
                index = 4;
                Destroy(other.gameObject);
                Time.timeScale = 0;
                break;
            case "Passenger6":
                index = 5;
                Destroy(other.gameObject);
                Time.timeScale = 0;
                break;
            case "Passenger7":
                index = 6;
                Destroy(other.gameObject);
                Time.timeScale = 0;
                break;
            case "Passenger8":
                index = 7;
                Destroy(other.gameObject);
                Time.timeScale = 0;
                break;
            case "Passenger9":
                index = 8;
                Destroy(other.gameObject);
                Time.timeScale = 0;
                break;
        }
	}
}