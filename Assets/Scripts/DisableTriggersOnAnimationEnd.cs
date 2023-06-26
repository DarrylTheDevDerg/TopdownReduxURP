using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTriggersOnAnimationEnd : MonoBehaviour
{
    public string[] triggerNames;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            foreach (string triggerName in triggerNames)
            {
                animator.ResetTrigger(triggerName);
            }
        }
    }
}
