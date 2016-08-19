using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    [Range(-10, 10)]
    public int gravity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other) {
        float direction = Vector3.Normalize(Vector3.Distance(other.transform.position, transform.position));
        other.gameObject.GetComponent<Rigidbody>().AddForce(Direction.TransformDirection(distance * Forward_Speed * Time.deltaTime));
    }
}
