using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnimator : MonoBehaviour
{
    public string parameterName = "SlashSpeed"; // Nombre del parámetro float en el Animator

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        float slashSpeed = PlayerPrefs.GetFloat("Slash Speed on Run", 1f);
        animator.SetFloat(parameterName, slashSpeed);
    }
}
