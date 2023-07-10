using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMultiplier : MonoBehaviour
{
    public GameObject prefab;
    public Color[] colors;

    private bool hasTrisword;
    private const float arcRadius = 2f;
    private const float arcAngle = 30f;

    private void Start()
    {
        // Obtener el valor de hasTrisword desde PlayerPrefs
        hasTrisword = PlayerPrefs.GetInt("hasTrisword", 0) == 1;

        if (hasTrisword)
        {
            GeneratePrefabs();
        }
    }

    private void GeneratePrefabs()
    {
        int prefabCount = Mathf.Min(3, colors.Length);

        for (int i = 0; i < prefabCount; i++)
        {
            float angle = (i - 1) * arcAngle;
            float radians = angle * Mathf.Deg2Rad;

            Vector3 position = transform.position + new Vector3(Mathf.Sin(radians) * arcRadius, i * 2, Mathf.Cos(radians) * arcRadius);
            Quaternion rotation = Quaternion.Euler(0f, -angle, 0f);

            GameObject spawnedPrefab = Instantiate(prefab, position, rotation);
            Renderer renderer = spawnedPrefab.GetComponent<Renderer>();

            // Asignar un color diferente a cada prefab
            renderer.material.color = colors[i];
        }
    }
}
