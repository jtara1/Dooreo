using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSpawner : MonoBehaviour
{
    private EnemyManager _enemyManager;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnAdditionalEnemyPeriodInSeconds = 15f;
    
    void Start()
    {
        _enemyManager = GetComponent<EnemyManager>();
        StartCoroutine(SpawnAdditionalEnemy());
    }

    /// <summary>
    /// Spawn a random enemy at a random spawn point w/ parent being EnemyManager
    /// </summary>
    public GameObject Spawn()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        int spawnerIndex = Random.Range(0, enemyPrefabs.Length);

        return Instantiate(
            enemyPrefabs[enemyIndex],
            _enemyManager.SpawnPoints[spawnerIndex].transform.position,
            Quaternion.identity,
            transform
        );
    }

    private IEnumerator SpawnAdditionalEnemy()
    {
        yield return new WaitForSeconds(spawnAdditionalEnemyPeriodInSeconds);
        _enemyManager.SpawnAndAddEnemy();
    }
}
