using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerupPrefab;

    float spawnRange = 9;
    int enemyCount;
    int waveNumber = 1;

    private void Start()
    {
        SpawnPowerup();
        SpawnEnemyWave(waveNumber);
    }

    private void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnPowerup();
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnPowerup() 
    {
        Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn) 
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPos() 
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(randomX, 0, randomZ);  
    }
}
