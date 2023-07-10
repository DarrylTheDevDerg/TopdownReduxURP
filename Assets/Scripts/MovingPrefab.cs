using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPrefab : MonoBehaviour
{
    public float initialSpeed = 1f;          // Velocidad inicial del prefab
    public float acceleration = 0.5f;        // Aceleración del prefab
    public float screenLimit = 10f;          // Límite de la pantalla en el eje X

    private float currentSpeed;              // Velocidad actual del prefab

    private void Start()
    {
        currentSpeed = initialSpeed;
        Destroy(gameObject, 2f);             // Se destruirá el prefab después de dos segundos
    }

    private void Update()
    {
        // Mueve el prefab en el eje X
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);

        // Aumenta la velocidad del prefab según la aceleración
        currentSpeed += acceleration * Time.deltaTime;

        // Verifica si el prefab ha alcanzado el límite de la pantalla
        if (transform.position.x >= screenLimit)
        {
            Destroy(gameObject);
        }
    }
}
