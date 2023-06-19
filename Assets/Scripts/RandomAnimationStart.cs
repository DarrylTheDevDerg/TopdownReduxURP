using UnityEngine;
using System.Collections;

public class RandomAnimationStart : MonoBehaviour
{
    public Animator animator;
    public float minDelay = 3f; // Tiempo m�nimo de retraso en segundos
    public float maxDelay = 10f; // Tiempo m�ximo de retraso en segundos

    void Start()
    {
        // Obtiene una referencia al componente Animator
        animator = GetComponent<Animator>();

        // Inicia la corutina para activar el Animator despu�s de un tiempo aleatorio
        StartCoroutine(StartAnimationAfterDelay());
    }

    IEnumerator StartAnimationAfterDelay()
    {
        // Espera un tiempo aleatorio entre minDelay y maxDelay segundos
        float delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);

        // Activa el Animator
        animator.enabled = true;
    }
}
