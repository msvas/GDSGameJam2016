using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinishLine : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			// Player has reached the end

			SceneManager.LoadScene("Stage");
		}
	}
}
