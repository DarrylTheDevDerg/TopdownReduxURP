using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public string triggerParameterName = "isMoving";

    private bool isPressedA = false;
    private bool isPressedD = false;

    private void Update()
    {
        // Detectar si el botón A está siendo presionado
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isPressedA = true;
            animator.SetTrigger(triggerParameterName);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isPressedA = false;
            animator.ResetTrigger(triggerParameterName);
        }

        // Detectar si el botón D está siendo presionado
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            isPressedD = true;
            animator.SetTrigger(triggerParameterName);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            isPressedD = false;
            animator.ResetTrigger(triggerParameterName);
        }
    }    
}
