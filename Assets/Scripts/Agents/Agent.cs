using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Agent : MonoBehaviour
{
    private bool _isDead = false;
    
    [SerializeField] protected int health = 10;

    /// <summary>
    /// Anything that needs to do something w/ enemy before he is destroyed
    /// </summary>
    public readonly UnityEvent<GameObject> PreDeath = new AgentDiedEvent();
    public readonly UnityEvent<GameObject> Died = new AgentDiedEvent();

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected bool Die()
    {
        if (!_isDead)
        {
            _isDead = true;
            PreDeath.Invoke(gameObject);
            Died.Invoke(gameObject);
            return true;
        }

        return false;
    }
}
