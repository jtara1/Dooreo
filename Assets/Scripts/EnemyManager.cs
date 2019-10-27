using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private NavMeshAgent[] _enemyAgents;
    [SerializeField]
    private Transform transformToFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        SetEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetToMoveTo();
    }

    void SetEnemies()
    {
        _enemyAgents = GetComponentsInChildren<NavMeshAgent>();
    }

    void SetTargetToMoveTo()
    {
        foreach (NavMeshAgent agent in _enemyAgents)
        {
            agent.SetDestination(transformToFollow.transform.position);
        }
    }
}
