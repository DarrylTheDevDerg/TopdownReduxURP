using UnityEngine;

public class ComponentDisabler : MonoBehaviour
{
    public string playerPrefsKey; // Clave para obtener el valor de PlayerPrefs
    public Behaviour componentToDisable; // Componente a desactivar

    private void Start()
    {
        // Verifica si la clave existe en PlayerPrefs
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            // Obtiene el valor almacenado en PlayerPrefs
            int storedValue = PlayerPrefs.GetInt(playerPrefsKey);

            // Desactiva el componente si el valor es 1 (o cualquier otro valor específico)
            if (storedValue == 1)
            {
                componentToDisable.enabled = false;
            }
        }
    }
}
