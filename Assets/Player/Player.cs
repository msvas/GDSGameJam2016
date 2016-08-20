using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private int index;

	[SerializeField]
	private bool grounded;

    private float bonusTime;
    private float starTime;
    private bool hasBonus = false;
    private bool hasStardust = false;

    public float bonusInterval = 5;
    public float starInterval = 5;

    private Movement movement;
	private Rigidbody rb;

	public bool isGrounded {
		get { return grounded; }
		set { grounded = value; }
	}

	private Vector3 planetCenter;
	
	void Start () {
        movement = GetComponent<Movement>();
		rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
		if (grounded) {
			//transform.up = (transform.position - planetCenter).normalized;
			Vector3 down = (planetCenter - transform.position).normalized;
			Vector3 forward = Vector3.Cross(transform.right, down);
			transform.rotation = Quaternion.LookRotation(-forward, -down);
		}

        if(hasBonus) {
            bonusTime += Time.deltaTime;
            if(bonusTime > bonusInterval) {
                hasBonus = false;
                movement.DecreaseSpeed(2);
            }
        }

        if(hasStardust) {
            starTime += Time.deltaTime;
            if (starTime > starInterval) {
                hasStardust = false;
                movement.RestoreSpeed();
            }
        }
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Planet")) {
			grounded = true;
			planetCenter = other.transform.position;
			rb.velocity = Vector3.zero;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Planet")) {
			grounded = false;
			planetCenter = Vector3.zero;
		}
	}

    public void ActivateNut() {
        if (!hasBonus) {
            hasBonus = true;
            bonusTime = 0;
            movement.IncreaseSpeed(2);
        }
    }

    public void ActivateStar() {
        if (!hasBonus && !hasStardust) {
            hasStardust = true;
            starTime = 0;
            movement.NullSpeed();
        }
    }

    /// <summary>
    /// Return the center of the planet the player is standing on
    /// </summary>
    public Vector3 GetPlanetCenter() {
		return planetCenter;
	}

	public int GetIndex() {
		return index;
	}
}
