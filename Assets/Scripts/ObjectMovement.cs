using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 5f;
    public Collider2D movementArea;
    
    private float minX;
    private float maxX;
    private float direction = 1f;

    private void Start()
    {
        // Obtener los límites del movimiento dentro del collider
        Vector2 minBounds = movementArea.bounds.min;
        Vector2 maxBounds = movementArea.bounds.max;
        
        // Calcular los valores mínimos y máximos en el eje X
        minX = minBounds.x;
        maxX = maxBounds.x;
    }

    private void Update()
    {
        // Mover el objeto en la dirección actual multiplicado por la velocidad y el tiempo
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        
        // Comprobar si alcanza los bordes del área de movimiento
        if (transform.position.x <= minX || transform.position.x >= maxX)
        {
            // Invertir la dirección
            direction *= -1f;
        }
    }
}

