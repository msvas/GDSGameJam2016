using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool grounded;

	public bool isGrounded {
		get { return grounded; }
		set { grounded = value; }
	}

	private Vector3 planetCenter;
	
	void Start () {
		
	}
	
	void Update () {
		if (grounded) {
			Vector3 up = (transform.position - planetCenter).normalized;
			float angle = Vector3.Angle(transform.up, up);

			transform.Rotate(new Vector3(0.0f, 0.0f, angle));
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Planet")) {
			grounded = true;
			planetCenter = other.transform.position;
		}
	}

	void OnTriggerLeave(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Planet")) {
			grounded = false;
			planetCenter = Vector3.zero;
		}
	}

	/// <summary>
	/// Return the center of the planet the player is standing on
	/// </summary>
	Vector3 GetPlanetCenter() {
		return planetCenter;
	}
}
