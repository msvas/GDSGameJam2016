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
}
