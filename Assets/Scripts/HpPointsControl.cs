using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPointsControl : MonoBehaviour
{
    public List<Image> hpUI;
    public PlayerController pc;
    public float maxHealth = 4f;
    public float currentHealth = 4f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = pc.health;
        UpdateHpUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            UpdateHpUI();
        }

        currentHealth = pc.health;
        UpdateHpUI();
    }

    public void UpdateHpUI()
    {
        for (int i = 0; i < hpUI.Count; i++)
        {
            if (currentHealth > i)
            {
                hpUI[i].gameObject.SetActive(true);

                // Reducir a la mitad el tamaño de la imagen si la vida está en un valor flotante con .5
                if (Mathf.Approximately(currentHealth, i + 0.5f))
                {
                    hpUI[i].rectTransform.localScale = new Vector3(0.5f, 0.5f, 1f);
                }
                else
                {
                    hpUI[i].rectTransform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
            else
            {
                hpUI[i].gameObject.SetActive(false);
            }
        }
    }
}
