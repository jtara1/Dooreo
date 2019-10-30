using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public ParticleSystem particleLauncher;
    public ParticleSystem splatterParticles;
    public Gradient particleColorGradient;
    public Gradient splatColorGradient;
    public GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform);
    }
}
