using UnityEngine;
using UnityEngine.UI;

public class TextCounter : MonoBehaviour
{
    public Text counterText;
    public MonoBehaviour targetMonoBehaviour;
    public string targetVariableName;

    private void Start()
    {
        // Asegurarse de que tienes asignado el componente Text al contador en el Inspector
        if (counterText == null)
        {
            Debug.LogError("El componente Text no est� asignado al contador. Asigna un objeto Text en el Inspector.");
        }

        // Asegurarse de que tienes asignado un MonoBehaviour y el nombre de la variable en el Inspector
        if (targetMonoBehaviour == null)
        {
            Debug.LogError("El MonoBehaviour objetivo no est� asignado. Asigna un objeto MonoBehaviour en el Inspector.");
        }
        else if (string.IsNullOrEmpty(targetVariableName))
        {
            Debug.LogError("El nombre de la variable objetivo no est� especificado. Asigna un nombre v�lido en el Inspector.");
        }
    }

    private void Update()
    {
        // Obtener el valor de la variable p�blica del MonoBehaviour objetivo utilizando reflexi�n
        var targetVariable = targetMonoBehaviour.GetType().GetField(targetVariableName);
        if (targetVariable != null)
        {
            var variableValue = targetVariable.GetValue(targetMonoBehaviour);

            // Actualizar el texto del contador con el valor de la variable p�blica
            counterText.text = variableValue.ToString();
        }
        else
        {
            Debug.LogError("La variable objetivo no fue encontrada en el MonoBehaviour especificado.");
        }
    }
}
