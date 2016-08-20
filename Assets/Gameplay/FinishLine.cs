using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed = 1.0f;

	void Start () {
	
	}
	
	void Update () {
		transform.Rotate(new Vector3(0.0f, 0.0f, rotationSpeed * Time.deltaTime));
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			// Player has reached the end
			Player player = other.gameObject.GetComponent<Player>();
			UI_Finish.Finish(player.GetIndex());

			Player[] ps = FindObjectsOfType<Player>();
			foreach (Player p in ps) {
				p.gameObject.GetComponent<Movement>().enabled = false;
				p.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
	}
}
