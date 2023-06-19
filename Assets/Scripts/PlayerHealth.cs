using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float normalHealAmount = 10f;
    public float specialHealAmount = 25f;
    public float specialHealthLossAmount = 15f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void HealNormal()
    {
        currentHealth += normalHealAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }

    public void HealSpecial()
    {
        currentHealth += specialHealAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }

    public void LoseSpecialHealth()
    {
        currentHealth -= specialHealthLossAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
    }

    void Die()
    {
        // Aquí puedes agregar lógica adicional cuando el jugador muere
    }
}
