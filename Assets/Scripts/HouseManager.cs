using UnityEngine;

public class HouseManager : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab of the object to spawn
    public Transform spawnPoint1; // First spawn point
    public Transform spawnPoint2; // Second spawn point

    public float spawnInterval = 5f; // Time interval between spawns
    public float destroyPosition = -10f; // Position where objects get destroyed

    private float timer = 0f; // Timer for spawning objects

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's time to spawn an object
        if (timer >= spawnInterval)
        {
            timer = 0f;

            // Spawn object at spawnPoint1
            SpawnObject(spawnPoint1);

            // Spawn object at spawnPoint2
            SpawnObject(spawnPoint2);
        }

        CheckDestroy();
    }

    void SpawnObject(Transform spawnPoint)
    {
        // Instantiate object at spawnPoint
        _ = Instantiate(objectPrefab, spawnPoint.position, Quaternion.identity);
    }

    void CheckDestroy()
    {
        GameObject[] spawnedObjects = GameObject.FindGameObjectsWithTag("House");
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj.transform.position.z <= destroyPosition)
            {
                Destroy(obj);
            }
        }
    }
}
