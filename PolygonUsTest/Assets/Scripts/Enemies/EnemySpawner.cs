using System.Collections;
using UnityEngine;

namespace Polygonus
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float initialSpawnInterval = 2f; // Initial time between enemy spawns
        [SerializeField] private float spawnIntervalStep = 0.1f; // Time interval reduction per second
        [SerializeField] private float maxSpawnInterval = 0.5f; // Minimum time interval between spawns
        [SerializeField] private float difficultyLimitTime = 5f; // Time limit for increasing difficulty

        private float currentSpawnInterval;
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
            currentSpawnInterval = initialSpawnInterval;
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            float elapsedTime = 0f;

            while (true)
            {
                // Calculate random spawn point at the edge of the camera
                Vector3 randomSpawnPoint = GetRandomEdgeSpawnPoint();

                // Spawn an enemy
                Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);

                // Increase the time between spawns based on elapsed time and difficulty limit
                if (elapsedTime < difficultyLimitTime)
                {
                    float newInterval = initialSpawnInterval - (spawnIntervalStep * elapsedTime);
                    currentSpawnInterval = Mathf.Max(newInterval, maxSpawnInterval);
                }

                // Wait for the next spawn
                yield return new WaitForSeconds(currentSpawnInterval);

                // Increment the elapsed time
                elapsedTime += currentSpawnInterval;
            }
        }

        private Vector3 GetRandomEdgeSpawnPoint()
        {
            // Randomly select which edge to spawn on
            int edge = Random.Range(0, 4);
            float randomX = 0f;
            float randomY = 0f;

            switch (edge)
            {
                case 0: // Top edge
                    randomX = Random.Range(0f, 1f);
                    randomY = 1.1f; // Spawn above the top edge
                    break;
                case 1: // Bottom edge
                    randomX = Random.Range(0f, 1f);
                    randomY = -0.1f; // Spawn below the bottom edge
                    break;
                case 2: // Left edge
                    randomX = -0.1f; // Spawn to the left of the left edge
                    randomY = Random.Range(0f, 1f);
                    break;
                case 3: // Right edge
                    randomX = 1.1f; // Spawn to the right of the right edge
                    randomY = Random.Range(0f, 1f);
                    break;
            }

            Vector3 viewportPoint = new Vector3(randomX, randomY, mainCamera.nearClipPlane);
            Vector3 spawnPoint = mainCamera.ViewportToWorldPoint(viewportPoint);
            return spawnPoint;
        }
    }
}
