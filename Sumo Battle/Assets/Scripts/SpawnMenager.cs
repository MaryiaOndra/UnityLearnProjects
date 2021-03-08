using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    float spawnRange = 9;

    private void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPos() 
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(randomX, 0, randomZ);    }
}
