using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    public MonoBehaviour targetMonoBehaviour;
    public string targetVariableName;
    public float scaleFactor = 0.1f;

    private SpriteRenderer spriteRenderer;
    private Collider2D objectCollider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<Collider2D>();

        // Asegurarse de que tienes asignado el SpriteRenderer y un Collider2D al objeto
        if (spriteRenderer == null)
        {
            Debug.LogError("El componente SpriteRenderer no está asignado al objeto.");
        }

        if (objectCollider == null)
        {
            Debug.LogError("No se encontró ningún Collider2D en el objeto.");
        }

        // Asegurarse de que tienes asignado el MonoBehaviour y el nombre de la variable en el Inspector
        if (targetMonoBehaviour == null)
        {
            Debug.LogError("El MonoBehaviour objetivo no está asignado. Asigna un objeto MonoBehaviour en el Inspector.");
        }
        else if (string.IsNullOrEmpty(targetVariableName))
        {
            Debug.LogError("El nombre de la variable objetivo no está especificado. Asigna un nombre válido en el Inspector.");
        }
    }

    private void Update()
    {
        // Obtener el valor de la variable del MonoBehaviour objetivo utilizando reflexión
        var targetVariable = targetMonoBehaviour.GetType().GetField(targetVariableName);
        if (targetVariable != null)
        {
            var targetValue = (float)targetVariable.GetValue(targetMonoBehaviour);

            // Modificar el tamaño del sprite y el collider utilizando el valor de la variable
            float newWidth = targetValue * scaleFactor;
            SetSpriteSize(newWidth);
            SetColliderSize(newWidth);
        }
        else
        {
            Debug.LogError("La variable objetivo no fue encontrada en el MonoBehaviour especificado.");
        }
    }

    private void SetSpriteSize(float newWidth)
    {
        if (spriteRenderer != null)
        {
            float currentHeight = spriteRenderer.bounds.size.y;
            spriteRenderer.transform.localScale = new Vector3(newWidth, currentHeight, 1f);
        }
    }

    private void SetColliderSize(float newWidth)
    {
        if (objectCollider != null)
        {
            if (objectCollider is BoxCollider2D boxCollider2D)
            {
                boxCollider2D.size = new Vector2(newWidth, boxCollider2D.size.y);
            }
            else if (objectCollider is CircleCollider2D circleCollider2D)
            {
                circleCollider2D.radius = newWidth / 2f;
            }
            else if (objectCollider is CapsuleCollider2D capsuleCollider2D)
            {
                capsuleCollider2D.size = new Vector2(newWidth, capsuleCollider2D.size.y);
                capsuleCollider2D.offset = new Vector2(0f, -capsuleCollider2D.size.y / 2f);
            }
            else if (objectCollider is PolygonCollider2D polygonCollider2D)
            {
                // No se puede escalar directamente un PolygonCollider2D, se debe duplicar y escalar los puntos
                Debug.LogWarning("No se puede escalar directamente un PolygonCollider2D. Se requiere duplicar y escalar los puntos manualmente.");
            }
            else
            {
                Debug.LogWarning("No se encontró ningún tipo de collider compatible. Asegúrate de que el objeto tenga un collider compatible.");
            }
        }
    }
}
