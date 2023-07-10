using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Health System")]
public class HealthSystemAttribute : MonoBehaviour
{
	public float health = 3.0f;
	private float maxHealth;


	// changes the energy from the player
	// also notifies the UI (if present)
	public void ModifyHealth(float amount)
	{
		//avoid going over the maximum health by forcin
		if(health + amount > maxHealth)
		{
			amount = maxHealth - health;
		}
			
		health += amount;

		//DEAD
		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
