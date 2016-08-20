using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlackHole : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // Player has reached the end
            //Player player = other.gameObject.GetComponent<Player>();

            Player[] ps = FindObjectsOfType<Player>();

			foreach (Player p in ps) {
				if (other.gameObject.GetComponent<Player>().GetIndex() != p.GetIndex())
					UI_Finish.Finish(p.GetIndex());

				p.gameObject.GetComponent<Movement>().enabled = false;
                p.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
}
