using UnityEngine;
using System.Collections;

public class Salir : MonoBehaviour
{
    public void SalirJuego()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
