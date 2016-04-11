using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float timer = 1f;
	public int score = 0;
	
	// Update is called once per frame
	void Update () {

		/*
		 * This here is a timer to delete anything that this script is attached to. 
		 */
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Destroy (gameObject);
		}
	}
}
