using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpriteChanger : MonoBehaviour
{
    public Sprite[] sprites;
    public int[] specialItemIds;
    public PlayerProgressRegistry playerProgressRegistry;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Elegir un id aleatorio
        int randomId = GetRandomId();

        // Verificar si el jugador ya tiene uno de los items "especiales"
        if (playerProgressRegistry != null && ContainsSpecialItem())
        {
            // Reemplazar el id por uno genérico si ya tiene un item "especial"
            randomId = GetGenericId();
        }

        // Cambiar el sprite según el id
        if (randomId >= 0 && randomId < sprites.Length)
        {
            spriteRenderer.sprite = sprites[randomId];
        }

        // Activar los booleanos correspondientes en PlayerProgressRegistry según el id
        if (playerProgressRegistry != null)
        {
            switch (randomId)
            {
                case 0:
                    playerProgressRegistry.hasBrimstone = true;
                    break;
                case 1:
                    playerProgressRegistry.hasTrisword = true;
                    break;
                case 2:
                    playerProgressRegistry.hasPwdSword = true;
                    break;
                // Agregar más casos según sea necesario para otros valores de id
                default:
                    break;
            }
        }
    }

    private int GetRandomId()
    {
        return Random.Range(0, sprites.Length);
    }

    private bool ContainsSpecialItem()
    {
        foreach (int itemId in specialItemIds)
        {
            if (HasItem(itemId))
            {
                return true;
            }
        }
        return false;
    }

    private bool HasItem(int itemId)
    {
        // Aquí debes implementar la lógica para verificar si el jugador ya tiene el item con el itemId específico
        // Por ejemplo, puedes usar PlayerPrefs o un sistema de inventario personalizado
        // Retorna true si el jugador tiene el item, de lo contrario, retorna false
        if (playerProgressRegistry.hasBrimstone || playerProgressRegistry.hasPwdSword || playerProgressRegistry.hasTrisword)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private int GetGenericId()
    {
        // Aquí puedes implementar la lógica para obtener un id genérico que no esté en la lista de specialItemIds
        // Por ejemplo, puedes generar un id aleatorio y verificar que no esté en la lista
        // Retorna el id genérico seleccionado
        return 3;
    }
}
