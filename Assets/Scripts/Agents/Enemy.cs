using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Agent
{
    [SerializeField] private int scoreValue = 100;
    private MultiAudioSource _multiAudioSource;

    public int ScoreValue => scoreValue;

    private void Start()
    {
        _multiAudioSource = GetComponent<MultiAudioSource>();
        PreDeath.AddListener(OnDeath);
    }

    private void OnDeath(GameObject self)
    {
        AudioManager.Instance.PlayOneShot(_multiAudioSource.GetRandomClip(), 1.5f);
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
        if (!IsDead) _multiAudioSource.PlayRandom(0.4f);
    }

}
