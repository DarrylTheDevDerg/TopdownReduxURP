using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private float attackStat;

    private void Start()
    {
        attackStat = PlayerPrefs.GetFloat("Attack Stat on Run", 3.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            float damage = attackStat; // Cantidad de daño basado en el valor de 'Attack Stat On Run'
            enemyHealth.ModifyHealth(-damage); // Reducir la vida del enemigo por la cantidad de daño
        }
    }
}
