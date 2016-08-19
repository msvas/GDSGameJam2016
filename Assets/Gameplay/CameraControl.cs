using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	[SerializeField]
	private Transform player;

	void Start () {
	
	}
	
	void Update () {
		Vector3 position = transform.position;
		position.x = player.position.x;
		position.y = player.position.y;

		transform.position = position;
	}
}
