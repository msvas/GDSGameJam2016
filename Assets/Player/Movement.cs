using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	[SerializeField]
	private string HorizontalInput = "Horizontal";

	[SerializeField]
	private string VerticalInput = "Vertical";

	[SerializeField]
	private string JumpInput = "Jump";

	private Player player;
	private Rigidbody rb;

	void Start () {
		player	= GetComponent<Player>();
		rb		= GetComponent<Rigidbody>();
	}
	
	void Update () {
		HandleInput();		
	}

	void HandleInput () {
		float horizontal	= Input.GetAxis(HorizontalInput);
		float vertical		= Input.GetAxis(VerticalInput);
		bool jump			= Input.GetAxis(JumpInput) > 0;

		if (player.isGrounded) {

			if (jump) {

			}

			if (horizontal != 0)
				MoveClockwise(horizontal);
			else if (vertical != 0)
				MoveCounterClockwise(vertical);
			
		}
		else {

			MoveInSpace(new Vector2(horizontal, vertical));

		}
	}

	void MoveClockwise (float input) {

	}

	void MoveCounterClockwise (float input) {

	}

	void MoveInSpace (Vector2 input) {
		Vector2 normalized = input.normalized;
		Vector3 movement = new Vector3(normalized.x, normalized.y, 0.0f);

		rb.AddForce(movement);
	}
}
