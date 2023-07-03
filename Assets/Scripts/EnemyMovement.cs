using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float detectionRadius = 3f;
    public Transform leftLimit;
    public Transform rightLimit;
    public string targetTag = "Player";

    private Rigidbody2D rb;
    private bool isMoving = false;
    private Transform target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            // Determina la dirección del movimiento
            Vector2 direction = target.position.x < transform.position.x ? Vector2.left : Vector2.right;

            // Aplica el movimiento al Rigidbody
            rb.velocity = direction * moveSpeed;

            // Verifica si ha alcanzado los límites de detección
            if ((direction == Vector2.right && transform.position.x >= rightLimit.position.x) ||
                (direction == Vector2.left && transform.position.x <= leftLimit.position.x))
            {
                // Detiene el movimiento si alcanza los límites
                StopMovement();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        // Verifica si hay objetos dentro del rango de detección
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        bool isTargetDetected = false;

        foreach (Collider2D obj in detectedObjects)
        {
            if (obj.CompareTag(targetTag))
            {
                // Se ha detectado un objeto con el tag especificado, comienza el movimiento hacia el objetivo
                isTargetDetected = true;
                target = obj.transform;
                break;
            }
        }

        if (isTargetDetected && !isMoving)
        {
            // Inicia el movimiento si se ha detectado el objetivo
            StartMovement();
        }
        else if (!isTargetDetected && isMoving)
        {
            // Detiene el movimiento si el objetivo ya no está dentro del rango de detección
            StopMovement();
        }
    }

    private void StartMovement()
    {
        isMoving = true;
    }

    private void StopMovement()
    {
        isMoving = false;
        rb.velocity = Vector2.zero;
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja el rango de detección en el editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Dibuja los límites de detección en el editor
        if (leftLimit != null && rightLimit != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(leftLimit.position, rightLimit.position);
        }
    }
}
