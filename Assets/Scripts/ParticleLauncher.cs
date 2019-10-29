using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    public ParticleSystem splatterParticles;
    public Gradient particleColorGradient;
    public Gradient splatColorGradient;
    public ParticleDecalPool splatDecalPool;

    [SerializeField] private float minimumFirePeriodInSeconds = 0.1f;
    private List<ParticleCollisionEvent> _collisionEvents;
    private float _lastFiredAtInSeconds = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, _collisionEvents);

        for (int i = 0; i < _collisionEvents.Count; i++)
        {
            splatDecalPool.ParticleHit(_collisionEvents[i], splatColorGradient);
            EmitAtLocation(_collisionEvents[i]);
        }
//        if(other.tag == "Enemy")
//        {
//            Health targetHealth = other.GetComponent<Health>();
//            targetHealth.DamageHealth(1);
//        }
    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        splatterParticles.transform.position = particleCollisionEvent.intersection;

        //        splatterParticles.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
        splatterParticles.transform.rotation = Quaternion.identity;
//        Debug.Log(splatterParticles.transform.rotation.eulerAngles);

        //ParticleSystem.MainModule psMain = splatterParticles.main;
        //psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));

        splatterParticles.Emit(1);
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log(Time.fixedTime);
        if (_lastFiredAtInSeconds + minimumFirePeriodInSeconds <= Time.fixedTime
            && Input.GetButton("Fire1")
        )
        {
            _lastFiredAtInSeconds = Time.fixedTime;
            
            ParticleSystem.MainModule psMain = particleLauncher.main;
            psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
            particleLauncher.Emit(1);
        }
    }
}

