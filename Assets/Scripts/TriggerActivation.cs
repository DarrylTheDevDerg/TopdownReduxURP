using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "ActivateTrigger";
    private int triggerHash;
    private float slashSpeedStat;

    private void Start()
    {
        triggerHash = Animator.StringToHash(triggerName);
        slashSpeedStat = PlayerPrefs.GetFloat("SlashSpeedStat", 1.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetFloat("SlashSpeedStat", slashSpeedStat);
            animator.SetTrigger(triggerHash);
        }
    }
}
