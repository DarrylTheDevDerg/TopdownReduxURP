using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public SpriteRenderer[] backgrounds;     // Lista de fondos a desplazar
    public float parallaxScale = 0.5f;       // Escala de desplazamiento del parallax

    private Transform playerTransform;       // Transform del jugador
    private Vector3 previousPlayerPosition;  // Posición anterior del jugador
    private Vector3 initialBackgroundPosition;  // Posición inicial del fondo

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        previousPlayerPosition = playerTransform.position;

        initialBackgroundPosition = transform.position;
    }

    private void Update()
    {
        Vector3 playerMovement = playerTransform.position - previousPlayerPosition;
        Vector3 backgroundMovement = playerMovement * parallaxScale;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            Vector3 targetPosition = initialBackgroundPosition + backgroundMovement * (i + 1);
            backgrounds[i].transform.position = targetPosition;
        }

        previousPlayerPosition = playerTransform.position;
    }
}
