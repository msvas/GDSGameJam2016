using UnityEngine;
using System.Collections;

public class PlanetGround : MonoBehaviour {

	[SerializeField]
	private float spinSpeed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0.0f, 0.0f, spinSpeed * Time.deltaTime));
	}
}
