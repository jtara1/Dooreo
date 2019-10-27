using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EMMovement : MonoBehaviour
{
    private EnemyManager _enemyManager;
    [SerializeField] private Transform transformToFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetToMoveTo();
    }

    void SetTargetToMoveTo()
    {
        foreach (NavMeshAgent agent in _enemyManager.EnemyNavMeshAgents)
        {
            agent.SetDestination(transformToFollow.transform.position);
        }
    }
}
