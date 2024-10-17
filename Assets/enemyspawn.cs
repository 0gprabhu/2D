 using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxEnemies = 5; // Limit the number of enemies on the screen

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // Only spawn new enemies if the limit is not reached
        if (timer >= spawnInterval && GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            SpawnEnemy();
            timer = 0f; // Reset the timer after spawning an enemy
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-8f, 8f);
        Vector2 spawnPosition = new Vector2(randomX, 5.5f); // Spawns above the screen
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
