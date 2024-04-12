using UnityEngine;
using NUnit.Framework;

public class PrefabSpawnerTests
{
    [Test]
    public void CreateSpawnSequence_Test()
    {
        var prefabSpawner = new GameObject().AddComponent<PrefabSpawner>();

        prefabSpawner.CreateSpawnSequence();

        Assert.AreEqual(42, prefabSpawner.spawnSequence.Count);

        Assert.AreEqual(prefabSpawner.oneCoinPrefab, prefabSpawner.spawnSequence[0].prefab);
        Assert.AreEqual(1, prefabSpawner.spawnSequence[0].lane);

        Assert.AreEqual(prefabSpawner.fencePrefab, prefabSpawner.spawnSequence[1].prefab);
        Assert.AreEqual(3, prefabSpawner.spawnSequence[1].lane);

        Assert.AreEqual(prefabSpawner.goToGameOver, prefabSpawner.spawnSequence[41].prefab);
        Assert.AreEqual(2, prefabSpawner.spawnSequence[41].lane);
    }
}
