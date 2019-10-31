using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    public ParticleSystem splatterParticles;
    public Gradient particleColorGradient;
    public Gradient splatColorGradient;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Character.Instance.transform);
    }
}
