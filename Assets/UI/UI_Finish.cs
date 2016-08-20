using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI_Finish : MonoBehaviour {

	private static UI_Finish instance;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private Text text;

	// Use this for initialization
	void Start () {
		instance = this;
		canvas.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void Finish(int winner) {
		instance.ShowFinishUI(winner);
	}

	private void ShowFinishUI(int winner) {
		canvas.gameObject.SetActive(true);
		text.text = "The winner is player " + winner + "!!";
	}

	public void On_Restart() {
		SceneManager.LoadScene("Stage");
	}

	public void On_BackToMenu() {

	}
}
