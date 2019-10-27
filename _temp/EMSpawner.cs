using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMSpawner : MonoBehaviour
{
    private EnemyManager _enemyManager;
    [SerializeField] private GameObject[] enemyPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Spawn a random enemy at a random spawn point w/ parent being EnemyManager
    /// </summary>
    void Spawn()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length - 1);
        int spawnerIndex = Random.Range(0, enemyPrefabs.Length - 1);

        Instantiate(
            enemyPrefabs[enemyIndex],
            _enemyManager.Spawners[spawnerIndex].transform.position,
            Quaternion.identity,
            transform
        );
    }
}
