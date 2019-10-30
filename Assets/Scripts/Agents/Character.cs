using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Agent
{
    public static Character Instance;
    public float intervalBetweenDamage = .5f;

    private float timeHurt;

    void Start()
    {
        Instance = this;
        
        Died.AddListener(OnDeath);
    }

    private void OnDeath(GameObject self)
    {
        Destroy(gameObject);
        GMScore.Instance.GameWon.Invoke(); // TODO: rm this, the laziest way to deal with player "lose" & death
    }

    private void OnParticleCollision(GameObject other)
    {
        if(Time.time > timeHurt + intervalBetweenDamage)
        {
            TakeDamage(1);
            timeHurt = Time.time;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Enemy" && (Time.time > timeHurt + intervalBetweenDamage))
        {
            TakeDamage(2);
            timeHurt = Time.time;
        }
        
    }
}
