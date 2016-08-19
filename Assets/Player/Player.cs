using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
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
			transform.up = (transform.position - planetCenter).normalized;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Planet")) {
			grounded = true;
			planetCenter = other.transform.position;
		}
	}

	void OnTriggerExit(Collider other) {
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
