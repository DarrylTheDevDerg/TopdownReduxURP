using UnityEngine;

public class AnimationTriggerManagement : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Este método será llamado desde los eventos de animación en el tiempo deseado
    public void ActivateTrigger(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }

    public void DisableTrigger(string triggerName)
    {
        animator.ResetTrigger(triggerName);
    }
}

