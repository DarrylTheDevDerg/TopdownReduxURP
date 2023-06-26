using UnityEngine;

public class DisableTriggerOnOtherAnimator : MonoBehaviour
{
    public Animator targetAnimator;
    public string triggerName;

    public void DisableTrigger()
    {
        if (targetAnimator != null)
        {
            targetAnimator.ResetTrigger(triggerName);
        }
    }
}
