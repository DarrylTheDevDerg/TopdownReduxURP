using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsUpdater : MonoBehaviour
{
    public PlayerProgressRegistry playerProgressRegistry;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener el ID del objeto que activa el collider
            int id = GetObjectID();

            // Actualizar los valores en PlayerPrefs según el ID
            UpdatePlayerPrefs(id);
        }
    }

    private int GetObjectID()
    {
        // Aquí puedes implementar la lógica para obtener el ID del objeto
        // Por ejemplo, puedes usar el nombre del objeto, su posición, o cualquier otra propiedad
        // En este ejemplo, se asume que el ID está representado por el nombre del objeto convertido a un número entero
        int id = int.Parse(gameObject.name);

        return id;
    }

    private void UpdatePlayerPrefs(int id)
    {
        if (playerProgressRegistry != null)
        {
            switch (id)
            {
                case 0:
                    PlayerPrefs.SetInt("HasBrimstone", playerProgressRegistry.hasBrimstone ? 1 : 0);
                    PlayerPrefs.GetFloat("Slash Speed Stat on Run", (playerProgressRegistry.slashSpeedStat + 3.5f));
                    break;
                case 1:
                    PlayerPrefs.SetInt("HasTrisword", playerProgressRegistry.hasTrisword ? 1 : 0);
                    PlayerPrefs.SetFloat("Slash Speed Stat on Run", (playerProgressRegistry.slashSpeedStat + 2.25f));
                    break;
                case 2:
                    PlayerPrefs.SetInt("HasPwdSword", playerProgressRegistry.hasPwdSword ? 1 : 0);
                    break;
                // Agrega más casos según sea necesario para otros valores de id
                default:
                    PlayerPrefs.SetFloat("Attack Stat on Run", (playerProgressRegistry.attackStat + 2.3f));
                    break;
            }

            PlayerPrefs.Save();
        }
    }
}
