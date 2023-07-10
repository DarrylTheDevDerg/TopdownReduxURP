using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float chargeTime = 2f;               // Tiempo de carga en segundos
    public Animator animator;                   // Referencia al Animator del jugador

    private bool isCharging = false;            // Indica si se está realizando la carga
    private float chargeTimer = 0f;             // Temporizador de carga

    public bool HasBrimstone = false;
    public bool hasPwdSword = false;
    public bool hasTrisword = false;

    public GameObject laserPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCharge();
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            if (isCharging)
            {
                ExecuteAction();
                StopCharge();
            }
        }

        if (PlayerPrefs.HasKey("HasBrimstone"))
        {
            PlayerPrefs.SetInt("HasBrimstone", HasBrimstone ? 1 : 0);
        }

        if (isCharging)
        {
            chargeTimer += Time.deltaTime;

            // Actualiza la animación de carga basada en el progreso de la carga
            float chargeProgress = Mathf.Clamp01(chargeTimer / chargeTime);
            animator.SetFloat("ChargeProgress", chargeProgress);

            if (chargeTimer >= chargeTime)
            {
                ExecuteAction();
                StopCharge();
            }
        }
    }

    private void StartCharge()
    {
        isCharging = true;
        chargeTimer = 0f;
        animator.SetBool("IsCharging", true);   // Inicia la animación de carga
    }

    private void StopCharge()
    {
        isCharging = false;
        chargeTimer = 0f;
        animator.SetBool("IsCharging", false);  // Detiene la animación de carga
        animator.SetTrigger("Action");          // Inicia la animación de acción
    }

    private void ExecuteAction()
    {
        if (HasBrimstone)
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
        }
    }
}
