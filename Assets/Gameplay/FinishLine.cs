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
            Player[] players = FindObjectsOfType<Player>();
            Player player = other.gameObject.GetComponent<Player>();
            if(players[0] == player) {
                UI_Finish.Finish(2);
            }
			else
                UI_Finish.Finish(1);

			foreach (Player p in players) {
				p.gameObject.GetComponent<Movement>().enabled = false;
				p.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
	}
}
