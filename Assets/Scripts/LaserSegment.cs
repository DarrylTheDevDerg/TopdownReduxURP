using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSegment : MonoBehaviour
{
    public GameObject headPrefab;            // Prefab de la cabeza del láser
    public GameObject bodyPrefab;            // Prefab del cuerpo del láser
    public GameObject tailPrefab;            // Prefab del desenlace del láser
    public float segmentDuration = 2f;       // Duración del segmento del láser
    public float damageAmount = 10f;         // Cantidad de daño infligido por el segmento

    private float destroyTimer;              // Temporizador para destruir el segmento del láser

    private void Start()
    {
        destroyTimer = segmentDuration;
    }

    private void Update()
    {
        // Actualiza el temporizador de destrucción
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el segmento del láser colisiona con un enemigo, le inflige daño
        if (collision.CompareTag("Enemy"))
        {
            // Coloca aquí tu lógica para infligir daño al enemigo
            Debug.Log("Enemy hit! Damage: " + damageAmount);
        }
    }

    public void CreateLaserSegments(int numSegments, Vector3 startPosition, Vector3 endPosition)
    {
        // Calcula la distancia total y la distancia entre cada segmento
        float totalDistance = Vector3.Distance(startPosition, endPosition);
        float segmentDistance = totalDistance / numSegments;

        // Crea los segmentos del láser
        for (int i = 0; i < numSegments; i++)
        {
            GameObject segmentPrefab;

            // Determina qué prefab se utilizará según la posición del segmento
            if (i == 0)
            {
                segmentPrefab = headPrefab;
            }
            else if (i == numSegments - 1)
            {
                segmentPrefab = tailPrefab;
            }
            else
            {
                segmentPrefab = bodyPrefab;
            }

            // Calcula la posición del segmento a lo largo del rayo láser
            Vector3 segmentPosition = Vector3.Lerp(startPosition, endPosition, (i + 1) / (float)numSegments);

            // Instancia el prefab del segmento del láser en la posición adecuada
            GameObject segment = Instantiate(segmentPrefab, segmentPosition, Quaternion.identity);
            segment.transform.LookAt(endPosition);
            segment.transform.localScale = new Vector3(segmentDistance, 1f, 1f);
        }
    }
}
