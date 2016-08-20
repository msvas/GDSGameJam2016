using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private int index;

	[SerializeField]
	private bool grounded;

    private float bonusTime;
    private bool hasBonus = true;

    public float bonusInterval = 5;

    private Movement movement;

	public bool isGrounded {
		get { return grounded; }
		set { grounded = value; }
	}

	private Vector3 planetCenter;
	
	void Start () {
        movement = GetComponent<Movement>();

    }
	
	void Update () {
		if (grounded) {
			transform.up = (transform.position - planetCenter).normalized;
		}

        if(hasBonus) {
            bonusTime += Time.deltaTime;
            if(bonusTime > bonusInterval) {
                hasBonus = false;
                movement.NormalSpeed();
            }
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

    public void ActivateNut() {
        if (!hasBonus) {
            hasBonus = true;
            bonusTime = 0;
            movement.DoubleSpeed();
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
