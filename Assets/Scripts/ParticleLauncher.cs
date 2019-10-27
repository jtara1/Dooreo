using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    public ParticleSystem splatterParticles;
    public Gradient particleColorGradient;
    public ParticleDecalPool splatDecalPool;

    List<ParticleCollisionEvent> collisionEvents;
    // Start is called before the first frame update
    void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
            EmitAtLocation(collisionEvents[i]);
        }
        if(other.tag == "Enemy")
        {
            Destroy(other);
        }
    }

    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        splatterParticles.transform.position = particleCollisionEvent.intersection;
        splatterParticles.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
        Debug.Log(splatterParticles.transform.rotation.eulerAngles);
        ParticleSystem.MainModule psMain = splatterParticles.main;
        psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));

        splatterParticles.Emit(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            ParticleSystem.MainModule psMain = particleLauncher.main;
            psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
            particleLauncher.Emit(1);
        }
    }
}

