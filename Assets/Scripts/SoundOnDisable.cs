using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnDisable : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnDisable()
    {
        // Comprobar si el objeto tiene un AudioSource y está activo
        if (audioSource != null && audioSource.gameObject.activeSelf)
        {
            // Comprobar si se ha asignado un AudioClip
            if (audioClip != null)
            {
                // Asignar el AudioClip al AudioSource
                audioSource.clip = audioClip;
            }

            // Reproducir el sonido
            audioSource.Play();
        }
    }
}
