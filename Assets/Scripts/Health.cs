using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings:")]
    [Range(1, 200)] public float maxHealth = 5.0f;
    public bool destroyOnDeath = true;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            if(destroyOnDeath)
            {
                Destroy(gameObject);
            }
        }
        else if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void HealHealth(float healAmount)
    {
        currentHealth += healAmount;
    }

    public void DamageHealth(float damageToHealth)
    {
        currentHealth -= damageToHealth;
    }
}
