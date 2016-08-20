﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	[SerializeField]
	private string HorizontalInput = "Horizontal";

	[SerializeField]
	private string VerticalInput = "Vertical";

	[SerializeField]
	private string JumpInput = "Jump";

	[SerializeField]
	private float speed = 10.0f;

    [SerializeField]
    private float normalSpeed = 10.0f;

    [SerializeField]
	private float jumpImpulse = 50.0f;

	[SerializeField][Range(0.01f, 1.0f)]
	private float friction = 0.8f;

	private Player player;
	private Rigidbody rb;

	public Transform otherPlayer;

	[SerializeField][Tooltip("Maximum distance between players")]
	private float maxDistance;

	[SerializeField]
	private float maxVelocity = 100;

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
				Jump();
			}

			if (horizontal < 0)
				MoveClockwise(horizontal);
			else if (horizontal > 0)
				MoveCounterClockwise(vertical);
		}
		else {

			if (horizontal != 0 || vertical != 0) {
				MoveInSpace(new Vector2(horizontal, vertical));
			}
			else {
				rb.velocity *= friction;
			}

			if (rb.velocity.magnitude > maxVelocity) {
				rb.velocity = maxVelocity * rb.velocity.normalized;
			}

			if ((otherPlayer.position - transform.position).magnitude > maxDistance) {
				transform.position = otherPlayer.position + maxDistance * (transform.position - otherPlayer.position).normalized;
			}
		}
	}

	void MoveClockwise (float input) {
		Vector3 direction = (Vector3.Cross(Vector3.forward, player.transform.up)).normalized;
		transform.position += direction * speed * Time.deltaTime;
		//rb.AddForce(direction * speed * Time.deltaTime);
	}

	void MoveCounterClockwise (float input) {
		Vector3 direction = (Vector3.Cross(player.transform.up, Vector3.forward)).normalized;
		transform.position += direction * speed * Time.deltaTime;
		//rb.AddForce(direction * speed * Time.deltaTime);
	}

	void MoveInSpace (Vector2 input) {
		Vector2 normalized = input.normalized;
		Vector3 movement = new Vector3(normalized.x, normalized.y, 0.0f);

		rb.AddForce(movement * speed * Time.deltaTime, ForceMode.VelocityChange);
	}

	void Jump () {
		rb.AddForce(
			(player.transform.up + rb.velocity).normalized * jumpImpulse * Time.deltaTime,
			ForceMode.Impulse);
	}

    public void IncreaseSpeed(int scale) {
        speed = speed * scale;
        Debug.Log("oi");
    }

    public void DecreaseSpeed(int scale) {
        speed = speed / scale;
    }

    public void NullSpeed() {
        speed = 0;
    }

    public void RestoreSpeed() {
        speed = normalSpeed;
    }
}
