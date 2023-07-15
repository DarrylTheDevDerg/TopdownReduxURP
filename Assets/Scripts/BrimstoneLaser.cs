using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(float damageAmount);
}

public class BrimstoneLaser : MonoBehaviour
{
    public Transform laserOrigin;
    public LineRenderer lineRenderer;
    public SpriteRenderer spriteRenderer;
    public Sprite[] laserSprites;

    private bool isFiring = false;

    private void Start()
    {
        // Inicializar el estado inicial del láser
        lineRenderer.enabled = false;
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        // Disparar el láser al presionar un botón
        if (Input.GetKeyDown(KeyCode.X) && !isFiring)
        {
            FireLaser();
        }
    }

    private void FireLaser()
    {
        // Configurar el estado de disparo del láser
        isFiring = true;
        lineRenderer.enabled = true;
        spriteRenderer.enabled = true;

        // Obtener la dirección del láser basado en la rotación del objeto de origen
        Vector3 laserDirection = laserOrigin.up;

        // Calcular el alcance del láser basado en la escala del objeto de origen
        float laserRange = laserOrigin.localScale.y;

        // Configurar la posición inicial y final del láser
        Vector3 startPos = laserOrigin.position;
        Vector3 endPos = startPos + laserDirection * laserRange;

        // Actualizar la posición de los puntos del LineRenderer
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

        // Configurar el sprite del láser basado en su dirección
        float angle = Mathf.Atan2(laserDirection.y, laserDirection.x) * Mathf.Rad2Deg;
        spriteRenderer.sprite = GetLaserSprite(angle);

        // Reproducir sonido de disparo

        // Restablecer el estado de disparo después de un tiempo
        float laserDuration = 0.5f;
        Invoke("ResetLaser", laserDuration);
    }

    private void ResetLaser()
    {
        // Restablecer el estado del láser
        isFiring = false;
        lineRenderer.enabled = false;
        spriteRenderer.enabled = false;
    }

    private Sprite GetLaserSprite(float angle)
    {
        // Calcular el índice del sprite basado en el ángulo del láser
        int spriteIndex = Mathf.RoundToInt(angle / 45f) + 3;
        spriteIndex = Mathf.Clamp(spriteIndex, 0, laserSprites.Length - 1);
        return laserSprites[spriteIndex];
    }
}