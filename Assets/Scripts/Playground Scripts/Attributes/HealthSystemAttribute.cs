using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Health System")]
public class HealthSystemAttribute : MonoBehaviour
{
	public float health = 3.0f;
	private float maxHealth;

	// Will be set to 0 or 1 depending on how the GameObject is tagged
	// it's -1 if the object is not a player
	private int playerNumber;



	private void Start()
	{

		// Set the player number based on the GameObject tag
		switch(gameObject.tag)
		{
			case "Player":
				playerNumber = 0;
				break;
			case "Player2":
				playerNumber = 1;
				break;
			default:
				playerNumber = -1;
				break;
		}
	}


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
