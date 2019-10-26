using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject player;
    public float minSpawnTime; // The minimum time to pass before spawning another enemy
    public float randomSpawnTime; // Max time added to minSpawnTime

    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        int difficulty = 0;
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            difficulty = PlayerPrefs.GetInt("Difficulty");
        }

        switch (difficulty)
        {
            case 0:
                this.minSpawnTime = 1.5f;
                this.randomSpawnTime = 1.5f;
                break;

            case 1:
                this.minSpawnTime = 1.0f;
                this.randomSpawnTime = 1.5f;
                break;

            case 2:
                this.minSpawnTime = 1.0f;
                this.randomSpawnTime = 1.0f;
                break;

            case 3:
                this.minSpawnTime = 0.2f;
                this.randomSpawnTime = 0.2f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            Vector3 spawnPosition = generateSpawnPosition(player.transform.position);
            Instantiate(enemyObject, spawnPosition, Quaternion.identity);

            resetTimer();
        }
    }

    private void resetTimer()
    {
        spawnTimer = (float)(minSpawnTime + Random.Range(0, randomSpawnTime));
    }

    private Vector3 generateSpawnPosition(Vector3 playerPosition)
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);
        Vector3 spawnPosition = new Vector3(x, 0.0f, z);
        return spawnPosition;
    }
}
