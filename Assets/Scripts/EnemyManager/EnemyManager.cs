using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    
    private List<GameObject> _enemies;
    private List<NavMeshAgent> _enemyNavMeshAgents;
    private List<GameObject> _spawnPoints;

    private GameManager _gameManager;
    private EMSpawner _emSpawner;

    public List<GameObject> SpawnPoints => _spawnPoints;
    public List<NavMeshAgent> EnemyNavMeshAgents => _enemyNavMeshAgents;
    public List<GameObject> Enemies => _enemies;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
        _gameManager = GameManager.Instance;
        _gameManager.Ping();
        _emSpawner = GetComponent<EMSpawner>();

        SetAttributes();
        AddDeathListeners();
    }

    void SetAttributes()
    {
        _enemies = new List<GameObject>();
        _enemyNavMeshAgents = new List<NavMeshAgent>();
        _spawnPoints = new List<GameObject>();
        
        foreach (Transform childTransform in transform)
        {
            switch (childTransform.tag)
            {
                case "Enemy":
                    _enemies.Add(childTransform.gameObject);
                    _enemyNavMeshAgents.Add(childTransform.gameObject.GetComponent<NavMeshAgent>());
                    break;
                case "Respawn":
                    _spawnPoints.Add(childTransform.gameObject);
                    break;
            }
        }
    }

    void AddDeathListeners()
    {
        foreach (GameObject enemy in _enemies)
        {
            AddDeathListener(enemy);
        }
    }
    
    void AddDeathListener(GameObject enemy)
    {
        enemy.GetComponent<Enemy>().Died.AddListener(OnEnemyDeath);
        _gameManager.AddEnemyDeathListener(enemy);
    }

    void OnEnemyDeath(GameObject deadEnemy)
    {
        if (_enemyNavMeshAgents.Remove(deadEnemy.GetComponent<NavMeshAgent>())
            || _enemies.Remove(deadEnemy))
        {
            Destroy(deadEnemy);
            SpawnAndAddEnemy();
        }
        else
        {
            Debug.LogWarning("EM: enemy already removed from agent & enemies lists");
        }
    }

    void SpawnAndAddEnemy()
    {
        GameObject newEnemy = _emSpawner.Spawn();
        _enemies.Add(newEnemy);
        _enemyNavMeshAgents.Add(newEnemy.GetComponent<NavMeshAgent>());
        AddDeathListener(newEnemy);
    }
}
