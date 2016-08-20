using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Credits : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("MainMenu");
		}
	}
}
