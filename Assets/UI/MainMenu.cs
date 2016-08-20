using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void On_Start() {
		SceneManager.LoadScene("Stage");
	}

	public void On_Credits() {
		SceneManager.LoadScene("Credits");
	}

	public void On_Exit() {
		Application.Quit();
	}
}
