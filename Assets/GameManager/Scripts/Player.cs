using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float health = 10;
    public float dmgAmount = 5;
	
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void TakeDamage()
    {
        health -= dmgAmount;

        if(health < 0)
        {
            GameManager.gameOver = true;
            GameManager.KillPlayer(this);
        }
    }
}
