﻿using UnityEngine;
using UnityEngine.SceneManagement;
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
			Player p = other.gameObject.GetComponent<Player>();
			Debug.Log("Winner is player " + p.GetIndex());

			SceneManager.LoadScene("Stage");
		}
	}
}
