using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimation : MonoBehaviour
{
    public string triggerName; // Nombre del trigger en el Animator
    public string tagToCheck; // Tag a verificar para activar el trigger

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que entra en contacto tiene el tag especificado
        if (other.gameObject.CompareTag(tagToCheck))
        {
            // Verificar si el objeto que entra en contacto tiene un Animator
            Animator animator = other.GetComponent<Animator>();
            if (animator != null)
            {
                // Activar el trigger especificado
                animator.SetTrigger(triggerName);
            }
        }
    }
}
