using UnityEngine;
using UnityEngine.UI;

public class CambiarTexto : MonoBehaviour
{
    public Text textoObjeto;
    public float tiempoEspera = 1f; // Tiempo en segundos antes de cambiar el texto
    public string nuevoTexto = "Nuevo texto"; // Texto que se va a cambiar

    private float temporizador = 0f;
    private bool textoCambiado = false;

    void Update()
    {
        if (!textoCambiado)
        {
            temporizador += Time.deltaTime;
            if (temporizador >= tiempoEspera)
            {
                textoObjeto.text = nuevoTexto;
                textoCambiado = true;
            }
        }
    }
}
