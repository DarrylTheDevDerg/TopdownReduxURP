using UnityEngine;

public class StaticTimeChecker : MonoBehaviour
{
    public float idleTimeThreshold = 5f;
    public UnityEngine.Events.UnityEvent onPlayerIdle;

    private float idleTime = 0f;
    private Vector3 lastCursorPosition;

    private void Start()
    {
        // Registrar la posición inicial del cursor
        lastCursorPosition = Input.mousePosition;
    }

    private void Update()
    {
        // Verificar si el cursor no se ha movido
        if (IsCursorIdle())
        {
            // Actualizar el tiempo de reposo acumulado
            idleTime += Time.deltaTime;

            // Verificar si se ha superado el umbral de tiempo
            if (idleTime >= idleTimeThreshold)
            {
                // Ejecutar la acción cuando el cursor no se ha movido durante el tiempo especificado
                onPlayerIdle.Invoke();
            }
        }
        else
        {
            // Reiniciar el tiempo de reposo acumulado cuando el cursor se mueve
            idleTime = 0f;
        }

        // Actualizar la posición del cursor registrada
        lastCursorPosition = Input.mousePosition;
    }

    private bool IsCursorIdle()
    {
        // Verificar si la posición actual del cursor es igual a la posición registrada anteriormente
        return Input.mousePosition == lastCursorPosition;
    }
}
