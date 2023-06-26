using UnityEngine;
using System;
using System.Reflection;

public class ScriptUsageInStartup : MonoBehaviour
{
    public MonoBehaviour targetScript; // Referencia al script objetivo
    public string methodName = "Void1"; // Nombre del método a ejecutar

    private void Start()
    {
        if (targetScript == null)
        {
            Debug.LogError("El script objetivo no está asignado en OtroScript.");
            return;
        }

        // Obtén el tipo del script objetivo
        Type targetType = targetScript.GetType();

        // Obtén el método utilizando el nombre del método
        MethodInfo methodInfo = targetType.GetMethod(methodName);

        // Verifica si el método existe
        if (methodInfo != null)
        {
            // Invoca el método en el objeto script objetivo
            methodInfo.Invoke(targetScript, new object[] { });
        }
        else
        {
            Debug.LogError("El método " + methodName + " no existe en " + targetType.Name + ".");
        }
    }
}
