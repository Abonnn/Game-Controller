using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Pengaturan Spawner")]
    public GameObject[] obstaclePrefabs;
    public float spawnInterval = 2f;
    public float spawnXPosition = 12f;

    [Header("Pengaturan Jalur")]
    public float[] laneYPositions;

    void Start()
    {
        StartCoroutine(SpawnObstaclesRoutine());
    }
    private IEnumerator SpawnObstaclesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            GameObject randomObstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            int randomLaneIndex = Random.Range(0, laneYPositions.Length);
            float spawnYPosition = laneYPositions[randomLaneIndex];
            Vector2 spawnPosition = new Vector2(spawnXPosition, spawnYPosition);
            Instantiate(randomObstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}