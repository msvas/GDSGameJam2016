using UnityEngine;
using System.Collections;

public class Stardust : MonoBehaviour {

    private int speed = 60;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Player>().ActivateStar();
        }
    }
}
