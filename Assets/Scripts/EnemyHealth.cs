using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Vida máxima del enemigo
    public float currentHealth; // Vida actual del enemigo

    public Animator animator;
    public string animatorTrigger;

    private void Start()
    {
        currentHealth = maxHealth; // Inicializar la vida actual al valor máximo al comienzo
    }

    public void ModifyHealth(float amount)
    {

        // cmbiar animartor
        animator.SetTrigger(animatorTrigger);
        currentHealth += amount; // Modificar la vida actual por la cantidad especificada

        // Verificar si la vida ha llegado a cero o menos
        if (currentHealth <= 0f)
        {
            Destroy(gameObject); // Destruir el objeto del enemigo
        }
    }
}
