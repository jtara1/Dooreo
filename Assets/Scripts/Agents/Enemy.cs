using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Agent
{
    [SerializeField] private int scoreValue = 100;
    
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

    public int ScoreValue { get; set; }
}
