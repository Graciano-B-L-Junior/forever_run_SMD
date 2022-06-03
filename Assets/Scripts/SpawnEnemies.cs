using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public const float height = 0.47f;
    public GameObject enemyToSpawn;
    public Transform player;
    public float timer = 5;
    public float timerMax = 5;
    public float timerMin = 1;
    public float spawnRange = 10;
    public float spawnPlace;
    public float distanceToPlayer = 80;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) 
        {   
            spawnPlace = Random.Range(-spawnRange, spawnRange);
            timer = Random.Range(timerMin, timerMax);
            Instantiate(enemyToSpawn, new Vector3(spawnPlace, height, player.position.z + distanceToPlayer), enemyToSpawn.transform.rotation);
        }
    }
}
