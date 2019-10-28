using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Agent : MonoBehaviour
{
    private bool _isDead = false;
    
    [SerializeField] protected int health = 10;

    public readonly UnityEvent<GameObject> Died = new AgentDiedEvent();


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected void Die()
    {
        if (!_isDead)
        {
            _isDead = true;
            
            Died.Invoke(gameObject);
            if (Died.GetPersistentEventCount() == 0)
            {
                Debug.LogWarning("Agent: no one listened to agent death");
                Destroy(gameObject);
            }   
        }
    }
}
