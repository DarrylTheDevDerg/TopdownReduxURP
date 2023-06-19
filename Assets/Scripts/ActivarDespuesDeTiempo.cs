using UnityEngine;
using System.Collections;

public class ActivarDespuesDeTiempo : MonoBehaviour
{
    public float tiempoEspera = 1f; // Tiempo en segundos antes de activar los objetos
    public GameObject[] objetosActivar;

    void Start()
    {
        StartCoroutine(ActivarObjetosDespuesDeTiempo());
    }

    IEnumerator ActivarObjetosDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoEspera);

        foreach (GameObject objeto in objetosActivar)
        {
            objeto.SetActive(true);
        }
    }
}
