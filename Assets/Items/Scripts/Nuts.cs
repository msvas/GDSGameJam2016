using UnityEngine;
using System.Collections;

public class Nuts : MonoBehaviour {

    private int speed = 20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.parent.position, Vector3.forward, speed * Time.deltaTime);
		transform.position.Set(transform.position.x, transform.position.y, 0);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Player>().ActivateNut();
            Object.Destroy(gameObject);
        }
    }
}
