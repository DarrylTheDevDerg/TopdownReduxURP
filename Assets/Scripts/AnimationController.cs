using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public string boolParameterName = "MovingCheck";
    public string triggerParameterName = " ";
    private float delay = 1f;
    private float timer = 0f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Slash Speed Stat on Run"))
        {
            delay = PlayerPrefs.GetFloat("Slash Speed Stat on Run", 2.0f);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        // Detectar si el botón A está siendo presionado

        if (timer >= delay && Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger(triggerParameterName);
            animator.SetBool(boolParameterName, false);
            timer = 0f;
        }
        else
        {
            animator.ResetTrigger(triggerParameterName);
            if (animator.GetBool(boolParameterName) == true)
            {
                animator.SetBool(boolParameterName, true);
            }
        }

        if ((Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.LeftArrow) == false) && (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.RightArrow) == false))
        {
            animator.SetBool(boolParameterName, false);
        }
        else
        {
            animator.SetBool(boolParameterName, true);
        }
    }   
}
