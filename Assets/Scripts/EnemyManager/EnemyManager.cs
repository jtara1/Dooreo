using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List<GameObject> _enemies;
    private List<GameObject> _spawners;

    public List<GameObject> Spawners => _spawners;
    public List<GameObject> Enemies => _enemies;

    // Start is called before the first frame update
    void Start()
    {
        SetAttributes();
        AddDeathListeners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetAttributes()
    {
        _enemies = new List<GameObject>();
        _spawners = new List<GameObject>();
        
        foreach (Transform childTransform in transform)
        {
            switch (childTransform.tag)
            {
                case "Enemy":
                    _enemies.Add(childTransform.gameObject);
                    break;
                case "Respawn":
                    _spawners.Add(childTransform.gameObject);
                    break;
            }
        }
    }

    void AddDeathListeners()
    {
        foreach (GameObject enemy in _enemies)
        {
            enemy.GetComponent<Enemy>().Died.AddListener(OnEnemyDeath);
        }
    }

    void OnEnemyDeath(GameObject deadEnemy)
    {
        if (_enemies.Remove(deadEnemy))
        {
            Destroy(deadEnemy);            
        }
    }
}
