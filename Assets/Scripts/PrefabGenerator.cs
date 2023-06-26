using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    public GameObject prefabToGenerate;

    private float delayTime = 0.0f;
    private float currentDelay = 0.0f;
    private bool isButtonPressed = false;

    private void Update()
    {
        // Actualizar el tiempo de retraso actual
        currentDelay -= Time.deltaTime;

        // Verificar si el botón se ha presionado
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isButtonPressed = true;
        }

        // Verificar si el botón se ha soltado
        if (Input.GetKeyUp(KeyCode.Z))
        {
            isButtonPressed = false;
        }

        // Verificar si el botón está presionado y ha pasado suficiente tiempo de retraso
        if (isButtonPressed && currentDelay <= 0)
        {
            // Generar el prefab
            GeneratePrefab();

            // Calcular el nuevo tiempo de retraso basado en slashSpeedStat
            float slashSpeedStat = PlayerPrefs.GetFloat("Slash Speed Stat", 2.0f);
            delayTime = 1 / slashSpeedStat;
            currentDelay = delayTime;
        }
    }

    private void GeneratePrefab()
    {
        // Generar el prefab en la posición actual del objeto
        GameObject generatedPrefab = Instantiate(prefabToGenerate, transform.position, Quaternion.identity);

        // Obtener el valor de rangeStat de las PlayerPrefs
        float rangeStat = PlayerPrefs.GetFloat("Range Stat", 1.25f);

        // Escalar el prefab horizontalmente basado en rangeStat
        Vector3 newScale = generatedPrefab.transform.localScale;
        newScale.x *= rangeStat;
        generatedPrefab.transform.localScale = newScale;
    }
}
