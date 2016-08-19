using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    [Range(-10, 10)]
    public int gravityIntensity;

	public int gravityScale = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player") && !other.gameObject.GetComponent<Player>().isGrounded) {
            Vector3 direction = Vector3.Normalize(transform.position - other.transform.position);
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * gravityIntensity * gravityScale * Time.deltaTime);
        }
    }
}
