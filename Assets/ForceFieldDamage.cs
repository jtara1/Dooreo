using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldDamage : MonoBehaviour
{
    public int damageDealt = 1;
    public float intervalBetweenDamage = .5f;

    private float timeDealtDamage;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && (Time.time > timeDealtDamage + intervalBetweenDamage))
        {
            other.GetComponent<Character>().TakeDamage(damageDealt);
            timeDealtDamage = Time.time;
        }
    }
}
