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

	void Start () {
		player = GetComponent<Player>();
	}
	
	void Update () {
		
	}

	void HandleInput() {

	}
}
