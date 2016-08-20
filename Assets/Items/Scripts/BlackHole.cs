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

    void OnCollisionEnter(Collision coll) {
        //Debug.Log("oi");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
