using UnityEngine;

public class DesactivarObjetoDespuesDeTiempo : MonoBehaviour
{
    public float tiempoDesactivar = 2.0f;

    void Start()
    {
        // Llama a la función DesactivarObjeto() después del tiempo especificado
        Invoke("DesactivarObjeto", tiempoDesactivar);
    }

    void DesactivarObjeto()
    {
        // Desactiva este objeto
        gameObject.SetActive(false);
    }
}
