using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject oneCoinPrefab;
    public GameObject twoCoinPrefab;
    public GameObject fencePrefab;
    public GameObject swayPrefab;
    public GameObject goToGameOver;

    public Transform[] spawnPoints;
    public float prefabSpawnInterval = 0.8f;
    public float coinSpawnInterval = 0.05f;

    private List<(GameObject prefab, int lane)> spawnSequence = new List<(GameObject prefab, int lane)>();

    private void Start()
    {
        CreateSpawnSequence();
        StartCoroutine(SpawnPrefabs());
    }

    private void CreateSpawnSequence()
    {
        spawnSequence.Add((oneCoinPrefab, 1)); // Coingroup on lane 1
        spawnSequence.Add((fencePrefab, 3)); // Fence on lane 3
        spawnSequence.Add((oneCoinPrefab, 3)); // Coingroup on lane 3
        spawnSequence.Add((swayPrefab, 2)); // Sway on lane 2
        spawnSequence.Add((oneCoinPrefab, 2)); // Coingroup on lane 2
        spawnSequence.Add((fencePrefab, 1)); // Fence on lane 1
        spawnSequence.Add((fencePrefab, 3)); // Fence on lane 3
        spawnSequence.Add((oneCoinPrefab, 1)); // Coingroup on lane 1
        spawnSequence.Add((fencePrefab, 2)); // Fence on lane 2
        spawnSequence.Add((twoCoinPrefab, 2)); // Coingroup on lane 2
        spawnSequence.Add((fencePrefab, 2)); // Fence on lane 2
        spawnSequence.Add((oneCoinPrefab, 1)); // Coingroup on lane 1
        spawnSequence.Add((fencePrefab, 3)); // Fence on lane 3
        spawnSequence.Add((swayPrefab, 2)); // Sway on lane 2
        spawnSequence.Add((fencePrefab, 1)); // Fence on lane 1
        spawnSequence.Add((twoCoinPrefab, 3)); // Coingroup on lane 3
        spawnSequence.Add((fencePrefab, 1)); // Fence on lane 1
        spawnSequence.Add((swayPrefab, 2)); // Sway on lane 2
        spawnSequence.Add((fencePrefab, 2)); // Fence on lane 2
        spawnSequence.Add((oneCoinPrefab, 2)); // Coingroup on lane 2
        spawnSequence.Add((fencePrefab, 2)); // Fence on lane 2
        spawnSequence.Add((oneCoinPrefab, 3)); // Coingroup on lane 3
        spawnSequence.Add((fencePrefab, 2)); // Fence on lane 2
        spawnSequence.Add((oneCoinPrefab, 2)); // Coingroup on lane 2
        spawnSequence.Add((fencePrefab, 3)); // Fence on lane 3
        spawnSequence.Add((oneCoinPrefab, 3)); // Coingroup on lane 3
        spawnSequence.Add((fencePrefab, 2)); // Fence on lane 2
        spawnSequence.Add((twoCoinPrefab, 1)); // Coingroup on lane 1
        spawnSequence.Add((fencePrefab, 3)); // Fence on lane 3
        spawnSequence.Add((swayPrefab, 2)); // Sway on lane 2
        spawnSequence.Add((fencePrefab, 1)); // Fence on lane 1
        spawnSequence.Add((oneCoinPrefab, 1)); // Coingroup on lane 1
        spawnSequence.Add((fencePrefab, 1)); // Fence on lane 1
        spawnSequence.Add((oneCoinPrefab, 2)); // Coingroup on lane 2
        spawnSequence.Add((fencePrefab, 3)); // Fence on lane 3
        spawnSequence.Add((swayPrefab, 2)); // Sway on lane 2
        spawnSequence.Add((oneCoinPrefab, 3)); // Coingroup on lane 3
        spawnSequence.Add((swayPrefab, 2)); // Sway on lane 2
        spawnSequence.Add((oneCoinPrefab, 2)); // Coingroup on lane 3
        spawnSequence.Add((swayPrefab, 2)); // Sway on lane 2
        spawnSequence.Add((oneCoinPrefab, 1)); // Coingroup on lane 3
        spawnSequence.Add((goToGameOver, 2)); //
    }

    private IEnumerator SpawnPrefabs()
    {
        yield return new WaitForSeconds(3f); 

        foreach ((GameObject prefab, int lane) in spawnSequence)
        {
            if (prefab == oneCoinPrefab || prefab == twoCoinPrefab)
            {
                for (int i = 0; i < 5; i++)
                {
                    Instantiate(prefab, spawnPoints[lane - 1].position, Quaternion.identity);
                    yield return new WaitForSeconds(coinSpawnInterval); 
                }
                yield return new WaitForSeconds((prefabSpawnInterval - (coinSpawnInterval * 5)));
            }
            else
            {
                Vector3 position = spawnPoints[lane - 1].position;
                Quaternion rotation = Quaternion.identity;

                if (prefab == swayPrefab)
                {
                    // Apply rotation for sway prefab
                    rotation = Quaternion.Euler(90, 0, 270);
                }

                Instantiate(prefab, position, rotation);
                yield return new WaitForSeconds(prefabSpawnInterval); 
            }
        }
    }
}
