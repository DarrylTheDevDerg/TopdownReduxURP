using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnPrefab
{
    public GameObject prefab;
    [Range(0f, 1f)]
    public float probability;
}

public class SpawnOnDestroy : MonoBehaviour
{
    public SpawnPrefab[] spawnPrefabs; // Array de prefabs a generar
    public float spawnRadius = 1f; // Radio de generación

    private void OnDestroy()
    {
        float totalProbability = 0f;

        foreach (SpawnPrefab spawnPrefab in spawnPrefabs)
        {
            totalProbability += spawnPrefab.probability;
        }

        float randomValue = Random.value * totalProbability;
        float cumulativeProbability = 0f;

        foreach (SpawnPrefab spawnPrefab in spawnPrefabs)
        {
            cumulativeProbability += spawnPrefab.probability;

            if (randomValue <= cumulativeProbability)
            {
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                Instantiate(spawnPrefab.prefab, spawnPosition, Quaternion.identity);
                break;
            }
        }
    }
}
