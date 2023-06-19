using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reemplaza "NombreDelTrigger" con el nombre del trigger que quieres activar
        GetComponent<Animator>().SetTrigger("ActivateAnimation");
    }
}
