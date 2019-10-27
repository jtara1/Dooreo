using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Agent
{
//    [SerializeField] private float speed = 2f;

    private void Start()
    {
//        GetComponent<NavMeshAgent>().speed = speed;
    }
    
    private void OnParticleCollision(GameObject other)
    {
        ParticleCollisionEvent[] events = new ParticleCollisionEvent[42];

        int hitCount = ParticlePhysicsExtensions.GetCollisionEvents(
            other.GetComponent<ParticleSystem>(),
            gameObject,
            events
        );
        
        TakeDamage(hitCount);
    }
}
