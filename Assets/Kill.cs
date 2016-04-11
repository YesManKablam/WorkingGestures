using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
	// Update is called once per frame

	//private GameObject enemy;
	Enemy enemy;
	private Score score;

	void Awake() {

		//enemy = Prefabs.load()
		//enemy = GameObject.Find ("CubeEnemy").GetComponent<Enemy> ();
		//enemy = Enemy.Hurt();
		score = GameObject.Find("Score").GetComponent<Score>();
	}

	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			
			//enemy = Enemy.Death();
			score.score += 100;
			Destroy(col.gameObject);
			//add an explosion or something
			//destroy the projectile that just caused the trigger collision
			//Destroy(gameObject);
		}

		if(col.gameObject.name == "StartCube")
		{
			Destroy (GameObject.FindWithTag("Myo"));
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}


}
