using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] enemies;
    public float maxSpawn = 5f;
    public float minSpawn = 3f;
    private float time;
    private float spawnDelay;


    void Start()
    {
        //InvokeRepeating("Spawn", spawnDelay, spawnTime);
        SetRandomTime();
        time = minSpawn;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time >= spawnDelay)
        {
            Spawn();
            SetRandomTime();
        }
    }

    void Spawn()
    {
        time = 0;
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnDelay = Random.Range(minSpawn, maxSpawn);
    }
}
