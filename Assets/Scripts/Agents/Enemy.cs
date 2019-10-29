using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Agent
{
    [SerializeField] private int scoreValue = 100;

    public int ScoreValue => scoreValue;

    private void Start()
    {
        PreDeath.AddListener(OnDeath);
    }

    private void OnDeath(GameObject self)
    {
        GetComponent<MultiAudioSource>().PlayRandom();
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
