using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int HP = 2;
    public int LiveTime = 2;
    public GameObject hundredPointsUI;
    //public float deathSpinMin = -100f;
    //public float deathSpinMax = 100f;

    private bool dead = false;
    private Score score;

    void Awake()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void FixedUpdate()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (HP <= 0 && !dead)
        {
            Death();
        }

        Destroy(gameObject, LiveTime);

    }


    public void Hurt()
    {
        HP--;
    }

    public void Death()
    {
        score.score += 100;

        // Set dead to true.
        dead = true;

        Collider2D[] cols = GetComponents<Collider2D>();
        foreach (Collider2D c in cols)
        {
            c.isTrigger = true;
        }

        Vector3 scorePos;
        scorePos = transform.position;
        scorePos.y += 0.5f;

        Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
    }

}
