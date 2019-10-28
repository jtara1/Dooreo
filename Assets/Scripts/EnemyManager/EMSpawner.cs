using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSpawner : MonoBehaviour
{
    private EnemyManager _enemyManager;
    [SerializeField] private GameObject[] enemyPrefabs;
    
    void Start()
    {
        _enemyManager = GetComponent<EnemyManager>();
    }

    /// <summary>
    /// Spawn a random enemy at a random spawn point w/ parent being EnemyManager
    /// </summary>
    public GameObject Spawn()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length - 1);
        int spawnerIndex = Random.Range(0, enemyPrefabs.Length - 1);

        return Instantiate(
            enemyPrefabs[enemyIndex],
            _enemyManager.SpawnPoints[spawnerIndex].transform.position,
            Quaternion.identity,
            transform
        );
    }
}
