using UnityEngine;

public class ComponentEnabler : MonoBehaviour
{
    public string playerPrefsKey; // Clave para obtener el valor de PlayerPrefs
    public Behaviour componentToEnable;

    private void Start()
    {

        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            // Obtiene el valor almacenado en PlayerPrefs
            int storedValue = PlayerPrefs.GetInt(playerPrefsKey);

            // Desactiva el componente si el valor es 1 (o cualquier otro valor específico)
            if (storedValue == 1)
            {
                componentToEnable.enabled = true;
            }
        }
    }
}
