using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool grounded;

	public bool isGrounded() { return grounded; }
	public void setGrounded (bool grounded) { this.grounded = grounded; }

	void Start () {
		
	}
	
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Planet")) {
			grounded = true;
		}
	}

	void OnTriggerLeave(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Planet")) {
			grounded = false;
		}
	}
}
