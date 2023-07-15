using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementY : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform topLimit;
    public Transform bottomLimit;

    private Rigidbody2D rb;
    private bool isMoving = false;
    private Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.down; // El enemigo se moverá hacia abajo inicialmente
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            // Aplica el movimiento al Rigidbody
            rb.velocity = moveDirection * moveSpeed;

            // Verifica si ha alcanzado los límites de movimiento
            if ((moveDirection == Vector2.up && transform.position.y >= topLimit.position.y) ||
                (moveDirection == Vector2.down && transform.position.y <= bottomLimit.position.y))
            {
                // Cambia la dirección del movimiento
                moveDirection *= -1;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        // Verifica si el enemigo está cerca de los límites y comienza a moverse
        if (!isMoving &&
            ((moveDirection == Vector2.up && transform.position.y <= topLimit.position.y) ||
             (moveDirection == Vector2.down && transform.position.y >= bottomLimit.position.y)))
        {
            StartMovement();
        }
    }

    private void StartMovement()
    {
        isMoving = true;
    }
}
