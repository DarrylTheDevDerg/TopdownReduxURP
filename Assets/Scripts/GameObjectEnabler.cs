using UnityEngine;

public class GameObjectEnabler : MonoBehaviour
{
    public string playerPrefsKey; // Clave para obtener el valor de PlayerPrefs
    public GameObject objectToEnable;

    private void Awake()
    {

        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            // Obtiene el valor almacenado en PlayerPrefs
            int storedValue = PlayerPrefs.GetInt(playerPrefsKey);

            // Desactiva el componente si el valor es 1 (o cualquier otro valor específico)
            if (storedValue == 1)
            {
                objectToEnable.SetActive(true);
            }
        }
    }
}
